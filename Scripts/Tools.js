//
//
//
function runEval(args, context) {
	eval(args);
}


function hideUnHide(controlId) {
	elem = document.getElementById(controlId);

	if (elem != null)
		elem.style.display = (elem.style.display == "block" || elem.style.display == "inline-block" || elem.style.display == "") ? "none" : "block";
}

function toggleCheckboxList(checkboxListName, checked) {
	checkboxList = document.getElementsByName(checkboxListName)

	for (var i = 0; i < checkboxList.length; i++)
		checkboxList[i].checked = checked;
}

function clearSelectOptions(controlId)
{
	ddlChild = document.getElementById(controlId);
	ddlChild.length = 0;
	ddlChild.add(new Option('Loading...','-1'));
}

function toggle(controlId)
{
	elem = document.getElementById(controlId);
	elem.style.display = (elem.style.display == "block" || elem.style.display == "inline-block" || elem.style.display == "") ? "none" : "block";
}

function toggleAll(sender, checkboxList) 
{
	for (var i = 0; i < checkboxList.length; i++)
	{
		checkboxList[i].checked = sender.checked ? true : false;
		row = checkboxList[i].parentElement.parentElement; //<--  go up 2 levels to the table row.

//		if (checkboxList[i].checked == true) 
//			styleRow(row, '#85ADFF', "#fff"); //Highlight the table row where the checkbox is found.  
//		 else 
//			styleRow(row, '#fff', "#000000"); // If the checkbox is not checked, take the highlight off the row.
	}
}

//Gets the number of checkboxes that are checked
function checkBoxCheckedCount(checkboxList)
{
	count = 0;

	for (var i = 0; i < checkboxList.length; i++)
	{
		if (checkboxList[i].checked)
			count++;
	}

	return count;
}

function checkbox_click()
{
	Source = event.srcElement

	//The element firing the event must be of checkbox type, which must
	//be inside a table cell, which in turn must be inside a table row.
	if ((Source.type == "checkbox") && (Source.parentElement.tagName == "TD") && (Source.parentElement.parentElement.tagName == "TR")) {
		row = Source.parentElement.parentElement; //<--  go up 2 levels to the table row.

		if (Source.checked == true)
			styleRow(row, '#85ADFF', "#fff"); //Highlight the table row where the checkbox is found.  
		else
			styleRow(row, '#fff', "#000000"); // If the checkbox is not checked, take the highlight off the row.
	}
}

function confirmDelete()
{
	if (checkBoxCheckedCount(document.getElementsByName("cbusers")) < 1)
	{
		alert("Please select one or more users you would like to delete.");
		return false;
	}
	else {
		return confirm("NOTE: You will not be able to recreate deleted users with the same e-mail address. Do you still want to delete the selected users?");
	}
}

function Timer(time)
{
	this.time = time;
	this.hTimer;
}

Timer.prototype.start = function ()
{
	var self = this;

	function updateTimer()
	{
		self.time -= 1000;
		self.hTimer = window.setTimeout(updateTimer, 1000)
		self.tick()
	}
	
	this.hTimer = window.setTimeout(updateTimer, 1000)
}

Timer.prototype.stop = function ()
{
	if (this.hTimer != null) 
		window.clearTimeout(this.hTimer)
	
	this.hTimer = null;
}

Timer.prototype.tick = function ()
{
	document.getElementById("uno").innerHTML = this.time;

	if (this.time <= 0)
		this.stop();
}


function openWindow(url, name, width, height, scrollbars, modal)
{
	scr = (scrollbars == true) ? "yes" : "no";
	var win;

	if (modal == true)
	{
		if (window.showModalDialog)
			window.showModalDialog(url, name, "dialogWidth:" + width + "px;dialogHeight:" + height + "px");
		else
			window.open(url, name, "width=" + width + ",height=" + height + ",status=no,scrollbars=" + scr + ';toolbar=no,directories=no,menubar=no,resizable=no,modal=yes');
	}
	else
		win = window.open(url, name, "width=" + width + ",height=" + height + ",status=1,scrollbars=" + scr);
	//win.focus();
}

function createProviderUser(npi) 
{
    win = window.open("usereditor.aspx?npi=" + npi, "NewUser", "width=650,height=300,top=450,left=400");
    win.focus();
   }

function getCtrlValue(controlId) {
	return document.getElementById(controlId).value;
}