
function setGrid(arg, context) 
{
	document.getElementById(context).innerHTML = arg;
	hideLoading();
}

function Row_DoCallback(control, argument, context)
{
	nav = navigator.appName.indexOf("Microsoft") != -1 ? "ie" : navigator.appName;

	cell = document.getElementById(context);
	row = cell.parentNode;

	if (nav == "ie")
		row.style.display = (row.style.display == "none") ? "inline-block" : "none";
	else
		row.style.display = (row.style.display == "none") ? "table-row" : "none";

	img = document.getElementById(row.id + "_img0");
	img.src = (img.src.indexOf("plus.gif") > 0) ? "https://careplanregistry.com/images/minus.gif" : "https://careplanregistry.com/images/plus.gif";

	if (!dataFetched(context))
	{
		WebForm_DoCallback(control, argument, setGrid, context, null, true)
		showLoading(context)
	}
	else
		hideLoading();
}

function initRow(rowId)
{
	nav = navigator.appName.indexOf("Microsoft") != -1 ? "ie" : navigator.appName;

	row = document.getElementById(rowId);

	if (nav == "ie")
		row.style.display = (row.style.display == "none") ? "inline-block" : "none";
	else
		row.style.display = (row.style.display == "none") ? "table-row" : "none";

	img = document.getElementById(rowId + "_img0");
	img.src = (img.src.indexOf("plus.gif") > 0) ? "https://careplanregistry.com/images/minus.gif" : "https://careplanregistry.com/images/plus.gif";
}


function styleRow(row, bgColor, fontColor) 
{
    row.style.color = fontColor;
    row.style.backgroundColor = bgColor;

    textNode = row.getElementsByTagName("td")

    for (var i = 0; i < textNode.length; i++)
        textNode[i].style.color = fontColor;
}

function dataFetched(ctrlId)
{
	ctrl = document.getElementById(ctrlId);
	return (ctrl.getElementsByTagName("table").length > 0);
}

var _img = null;
function showLoading(targetId)
{
	if (_img == null)
	{
		_img = document.createElement("img");
		_img.setAttribute("src", "https://pass.ilshealth.com/images/loading.gif");
		_img.setAttribute("style", "position:absolute");
		_img.setAttribute("alt", "Loading Grid");

		document.body.appendChild(_img);
	}

	ctrl = document.getElementById(targetId);

	pos = findPos(ctrl);

	_img.style.display = "block";
	_img.style.top = pos[1] + 100 + "px";
	_img.style.left = pos[0] + 300 + "px";
}

function hideLoading()
{
	if (_img != null)
		_img.style.display = "none";
}

function findPos(oElement)
{
	if (typeof (oElement.offsetParent) != 'undefined')
	{
		for (var posX = 0, posY = 0; oElement; oElement = oElement.offsetParent)
		{
			posX += oElement.offsetLeft;
			posY += oElement.offsetTop;
		}
		return [posX, posY];
	}
	else {
		return [oElement.x, oElement.y];
	}
}

function getPageOffset()
{
	var iebody = (document.compatMode && document.compatMode != "BackCompat") ? document.documentElement : document.body

	var offsetLeft = document.all ? iebody.scrollLeft : pageXOffset
	var offsetTop = document.all ? iebody.scrollTop : pageYOffset

	return offsetTop;
}