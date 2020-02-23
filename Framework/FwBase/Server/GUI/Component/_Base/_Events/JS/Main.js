/* ##################### Events ##################### */

function OnClick(sender) { invokeEvent(sender, "OnClick"); }

function OnDbClick(sender) { invokeEvent(sender, "OnDbClick"); }

function OnMouseDown(sender) { invokeEvent(sender, "OnMouseDown"); }

function OnMouseMove(sender) { invokeEvent(sender, "OnMouseMove"); }

function OnMouseOut(sender) { invokeEvent(sender, "OnMouseOut"); }

function OnMouseOver(sender) { invokeEvent(sender, "OnMouseOver"); }

function OnMouseUp(sender) { invokeEvent(sender, "OnMouseUp"); }

function OnWheel(sender) { invokeEvent(sender, "OnWheel"); }

/* ##################### Engine ##################### */

function invokeEvent(sender, eventType) {
	var url = "invokeEvent?SenderId=" + sender.id + "&EventType=" + eventType;
	$.get(url,
		function(data) {
			refreshContent(data);
		});
}

function refreshContent(data) {
	if (data == null) {
		console.warn("Cannot refresh content due to empty data.");
		return;
	}
    console.info("'Refresh screen' request received.");
	if (!data.Modified) {
        console.log("Nothing to change.");
	}
	data.Elements.forEach(x => refreshContent(x));
}

function refreshComponent(data) {
	var element = document.getElementById(data.ComponentId);
	if (element == null) {
		console.warn("Cannot refresh component. Cannot find component with ID=" + data.ComponentId);
		return;
	}
	item.value = data.HtmlContent;
}

function clientAction(sender, eventType) {
	var url = "clientAction?id=" + sender.id + concat("&eventType=").concat(eventType);
    $.get(url, function(data, status){
       alert("Data: " + data + "\nStatus: " + status);
    });
}
