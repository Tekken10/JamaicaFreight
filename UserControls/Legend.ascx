<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Legend.ascx.cs" Inherits="UserControls_Legend" %>

<fieldset>
<legend>Legend</legend>

<ul style="list-style-type:none">
	<li style="list-style-image:url(images/exclamation.png)"> Member has stratified as High Risk</li>
	<li style="list-style-image:url(images/cases.png)"> Member Profile contains information mapped from clinical and other history if available and completed Health Risk Assessment (HRA) if available. Can be opened, viewed and printed in pdf</li>
	<li style="list-style-image:url(images/profile.png)"> Completed Health Risk Assessment (HRA) of Member.  Can be opened, viewed and printed in pdf</li>
	<li style="list-style-image:url(images/careplan.png)"> Care Plan contains Problems, Goals and Interventions based on the HRA. Members without an HRA will have an Unreachable Care Plan based on generic Problems, Goals and Interventions. Can be opened, viewed and printed in pdf</li>
</ul>

</fieldset>

<p>
Not all members have available data in order  to populate the above and therefore what you view may be very general and based on the available data.  If you would like us to attempt to 
complete an HRA for one of your patients, please click on this link, <asp:HyperLink ID="HyperLink1" NavigateUrl="mailto:caremgmt@partnersathome.com" runat="server">caremgmt@partnersathome.com</asp:HyperLink> 
and give us the patient’s name and most current telephone number.  We will contact them and make every effort to complete an HRA.
</p>