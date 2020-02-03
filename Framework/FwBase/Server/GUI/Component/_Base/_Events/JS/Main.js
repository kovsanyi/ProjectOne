function clientAction(sender, eventType){
    var url = "clientAction?id="+sender.id+"&eventType="+eventType;
    $.get(url, function(data, status){
       alert("Data: " + data + "\nStatus: " + status);
    });
}
