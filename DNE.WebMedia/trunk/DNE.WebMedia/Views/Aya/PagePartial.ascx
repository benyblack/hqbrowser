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
    <span id="loading">
        <img class="loading" alt="" src="/img/1.gif" /></span><span id="play-info"></span>
</p>
<div style="direction: rtl; text-align: justify;">
    <% foreach (var item in Model) { %>
    <%if (item.AyaNo == 1) {%>
    <h3>
        <%:item.Sura %></h3>
    <%} %>
    <%if (item.AyaNo == 1 && item.SuraNo != 9 && item.SuraNo != 1) {%>
    <h2>
        بِسْمِ اللَّهِ الرَّحْمَٰنِ الرَّحِيمِ</h2>
    <%} %>
    <span class="aya" id='<%=string.Format("{0:D3}{1:D3}", item.SuraNo, item.AyaNo) %>'>
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
<div id="jpId">
</div>
<script type="text/javascript" src="/Scripts/PagePartial.js"></script>
