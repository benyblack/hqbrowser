<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<DNE.WebMedia.Model.PageAyaSimple>>" %>
<% int pageno = int.Parse(Html.ViewContext.RouteData.Values["pageno"].ToString());
   string langid = "fa";
   if (Request["langid"] != null)
       langid = Request["langid"].ToString();
%>
<p align="left">
    <%if (pageno < 604) { %>
    <a href='/Pages/<%=(pageno + 1) %>' class="button" onclick='gopage(<%=(pageno + 1) %>,"<%=langid %>");return false;'>
        Next</a>
    <%} %>
    <%if (pageno > 1) { %>
    <a href='/Pages/<%=(pageno - 1) %>' class="button" onclick='gopage(<%=(pageno - 1) %>,"<%=langid %>");return false;'>
        Prev</a>
    <%} %>
</p>
<div style="direction: rtl; text-align: justify;">
    <% foreach (var item in Model) { %>
    <%if (item.AyaNo == 1) {%>
    <h3>
        <%:item.Sura %></h3>
    <%} %>
    <%if (item.AyaNo == 1 && item.SuraNo != 9 && item.SuraNo != 1) {%>
    <h2>بِسْمِ اللَّهِ الرَّحْمَٰنِ الرَّحِيمِ</h2>
    <%} %>
    <span class="aya">
        <%: item.TextFull %>
        <div class='tooltip <%:langid=="fa"?"rtl":"ltr" %>'>
            <%: item.Translate%>
        </div>
    </span>(<%: item.AyaNo%>)
    <% } %>
</div>
<p align="left">
    <%if (pageno < 604) { %>
    <a href='/Pages/<%=(pageno + 1) %>' class="button" onclick='gopage(<%=(pageno + 1) %>,"<%=langid %>");return false;'>
        Next</a>
    <%} %>
    <%if (pageno > 1) { %>
    <a href='/Pages/<%=(pageno - 1) %>' class="button" onclick='gopage(<%=(pageno - 1) %>,"<%=langid %>");return false;'>
        Prev</a>
    <%} %>
</p>
<script type="text/javascript">
$(document).ready(function(){
    $("#cbotranslate").val("<%=langid%>");
});
function gotranslate(ctl) {
    gopage(<%=pageno%>,ctl.value);
}
</script>
