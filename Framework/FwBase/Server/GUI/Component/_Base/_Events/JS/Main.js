/* ##################### Events ##################### */

function OnClick(sender) { invokeEvent(sender, "OnClick"); }

function OnDbClick(sender) { invokeEvent(sender, "OnDbClick"); }

function OnMouseDown(sender) { invokeEvent(sender, "OnMouseDown"); }

function OnMouseMove(sender) { invokeEvent(sender, "OnMouseMove"); }

function OnMouseOut(sender) { invokeEvent(sender, "OnMouseOut"); }

function OnMouseOver(sender) { invokeEvent(sender, "OnMouseOver"); }

function OnMouseUp(sender) { invokeEvent(sender, "OnMouseUp"); }

function OnWheel(sender) { invokeEvent(sender, "OnWheel"); }

function OnBlur(sender) { invokeEvent(sender, "OnBlur"); }

/* ##################### Engine ##################### */

function invokeEvent(sender, eventType) {
	var data = "InvokeEvent&EventType=" + eventType;
	clientAction(sender, data);
}

function clientAction(sender, data) {
	var url = window.location.href + "&ClientAction=" + data + "&SenderValue=" + sender.value + "&SenderId=" + sender.id;
	var urlEncoded = encodeURI(url);
	$.get(urlEncoded, function(dataReceived, status) {
		refreshContent(JSON.parse(dataReceived));
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
	data.Elements.forEach(x => refreshComponent(x));
}

function refreshComponent(data) {
	var element = document.getElementById(data.ComponentId);
	if (element == null) {
		console.warn("Cannot refresh component. Cannot find component with ID=" + data.ComponentId);
		return;
	}
	$(element).replaceWith(data.HtmlContent);
}
