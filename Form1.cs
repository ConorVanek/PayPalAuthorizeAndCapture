using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using PayPalCheckoutSdk.Payments;
//using PayPalCheckoutSdk.Core;
//using BraintreeHttp;
//using PayPalHttp;

namespace paypal_capture
{
    public partial class PayPalCapture : Form
    {
        string connectionString = "CONNECTION_STRING_HERE";

        public PayPalCapture()
        {
            InitializeComponent();
            fullAmountRadioButton.Checked = true;
            getOrders(Orders);
        }


        private void getOrders(ListBox orders)
        {
            orders.Items.Clear();
            string sql = "SELECT [paypalorderid] FROM [TonyWorkArea].[dbo].[paypalauth] order by [id]";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        orders.Items.Add(reader["paypalorderid"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string getAuthID(string orderid)
        {
            string authID = "";
            string sql = "SELECT [authorizationcode] from [TonyWorkArea].[dbo].[paypalauth] where [paypalorderid] = @orderid";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@orderid", orderid);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        authID = reader["authorizationcode"].ToString();
                    }
                    reader.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return authID;
        }

        private string getTotal(string orderid)
        {
            string total = "";
            string sql = "SELECT [total] from [TonyWorkArea].[dbo].[paypalauth] where [paypalorderid] = @orderid";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@orderid", orderid);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        total = reader["total"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return total;
        }

        public async static Task<PayPalHttp.HttpResponse> VoidAuth(string AuthorizationId)
        {
            // A PayPal authorization can be cancelled with only two lines of code, shown below.

            var request = new AuthorizationsVoidRequest(AuthorizationId);

            //3. Call PayPal to void an authorization.
            var response = await PayPalClient.client().Execute(request);


            //4. Save the capture ID to your database for future reference.
            return (PayPalHttp.HttpResponse)response;
        }


        public async static Task<PayPalHttp.HttpResponse> CaptureAuth(string AuthorizationId, bool debug = false, string dollaramount = "")
        {
            var request = new AuthorizationsCaptureRequest(AuthorizationId);
            
            request.Prefer("return=representation");
            if (dollaramount == "")
            {
                // If you do not specify the dollar amount in the capture request, it simply defaults to the full amount.
                request.RequestBody(new CaptureRequest());
            }
            else
            {
                // This is how you make a PayPal capture request for a partial amount. 
                CaptureRequest capturerequest = new CaptureRequest
                {
                    Amount = new Money
                    {
                        CurrencyCode = "USD",
                        Value = dollaramount
                    }
                };
                request.RequestBody(capturerequest);
            }

            //3. Call PayPal to capture an authorization.
            var response = await PayPalClient.client().Execute(request);


            //4. Save the capture ID to your database for future reference.
            if (debug)
            {
                var result = response.Result<PayPalCheckoutSdk.Payments.Capture>();
                Console.WriteLine("Status: {0}", result.Status);
                Console.WriteLine("Order Id: {0}", result.Id);
                Console.WriteLine("Links:");
                foreach (LinkDescription link in result.Links)
                {
                    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel,
                                            link.Href,
                                            link.Method);
                }
                Console.WriteLine("Response JSON: \n {0}",
                            PayPalClient.ObjectToJSONString(result));
            }
            return (PayPalHttp.HttpResponse)response;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            getOrders(this.Orders);
        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {
            
            string partialAmount = partialRadioButton.Checked ? partialAmountTextBox.Text.ToString() : "";
            Regex money = new Regex(@"[0-9]+[\.]*[0-9]*");
            MatchCollection matches = money.Matches(partialAmount);
            if(partialRadioButton.Checked && (matches.Count != 1 || partialAmount == ""))
            {
                MessageBox.Show("Please enter a valid dollar amount.");
                return;
            }

            string orderid = this.Orders.SelectedItem.ToString();
            MessageBox.Show("Selected Orderid: " + orderid);
            string authid = getAuthID(orderid);
            if(authid == "")
            {
                MessageBox.Show("Could not get Authorization code. :(");
            }
            else
            {
                var captureresponse = CaptureAuth(authid, true, partialAmount);
            }
        }

        private void fullAmountRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fullAmountRadioButton.Checked)
            {
                partialAmountTextBox.Clear();
                partialAmountTextBox.Enabled = false;
                partialRadioButton.Checked = false;
            }
        }

        private void partialRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (partialRadioButton.Checked)
            {
                partialAmountTextBox.Enabled = true;
                fullAmountRadioButton.Checked = false;
            }
        }

        private void Orders_SelectedValueChanged(object sender, EventArgs e)
        {
            string currentOrderID = Orders.SelectedItem.ToString();
            string total = getTotal(currentOrderID);
            try
            {
                var convertdecimal = Convert.ToDecimal(total);
                AmountLabel.Text = "Total: " + String.Format("{0:0.##}", convertdecimal);
            }
            catch
            {
                AmountLabel.Text = "Total: " + total;
            }
            
        }

        private void voidButton_Click(object sender, EventArgs e)
        {
            string orderid = this.Orders.SelectedItem.ToString();
            MessageBox.Show("Selected Orderid: " + orderid);
            string authid = getAuthID(orderid);
            if (authid == "")
            {
                MessageBox.Show("Could not get Authorization code. :(");
            }
            else
            {
                VoidAuth(authid);
            }
        }
    }
}
