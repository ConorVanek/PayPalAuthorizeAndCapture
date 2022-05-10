<?php

if(empty($_POST)) {
	echo("is empty\n");
	$_POST = json_decode(file_get_contents('php://input', true));
	$orderid = $_POST->{"orderID"};
	$authid = $_POST->{"authorizationID"};
	$ordertotal = $_POST->{"total"};
	echo($orderid );
	echo($authid);
	echo("\nTotal: " . $ordertotal);

		
	$serverName = "server_name"; //serverName\instanceName
	$connectionInfo = array( "Database"=>"db_name", "ConnectionPooling"=>"false");

	$conn = sqlsrv_connect( $serverName, $connectionInfo);

	if($conn) {
		echo "Connection established.<br />";
    	$sql = "INSERT INTO paypalauth (paypalorderid, authorizationcode, total) VALUES (?, ?, ?)";
		$params = array($orderid, $authid, $ordertotal);

		$stmt = sqlsrv_query( $conn, $sql, $params);
		if( $stmt === false ) {
			die( print_r( sqlsrv_errors(), true));
		}
	}
	else{
		echo "Connection could not be established.<br />";
		die( print_r( sqlsrv_errors(), true));
	}
}

?>