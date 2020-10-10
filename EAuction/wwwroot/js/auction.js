"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/auctionhub").build();




    connection.on("ReceiveOrderUpdate", function() {
        //const statusDiv = document.getElementById("status");
        //statusDiv.innerHTML = update;
       // alert('received!');
    }
    );

  

    connection.on("finished", function () {
        connection.stop();
    }
    );

    connection.start()
        .catch(err => console.error(err.toString()));
