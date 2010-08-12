<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<DNE.WebMedia.Model.PageAya>>" %>
<p align="left">
    <%if (Model.First().PageId < 604) { %>
    <a href='/Pages/<%=(Model.First().PageId + 1) %>' class="button" onclick='gopage(<%=(Model.First().PageId + 1) %>);return false;'>
        Next</a>
    <%} %>
    <%if (Model.First().PageId > 1) { %>
    <a href='/Pages/<%=(Model.First().PageId - 1) %>' class="button" onclick='gopage(<%=(Model.First().PageId - 1) %>);return false;'>
        Prev</a>
    <%} %>
</p>
<div style="direction: rtl; text-align: justify;">
    <% foreach (var item in Model) { %>
    <%if (item.AyaNo == 1) {%>
    <h3>
        <%:item.Aya.sura %></h3>
    <%} %>
    <%if (item.AyaNo == 1 && item.SuraNo != 9) {%>
    <h2>
        بِسْمِ اللَّهِ الرَّحْمَٰنِ الرَّحِيمِ</h2>
    <%} %>
    <span class="aya">
        <%: item.Aya.TextFull %>
        <span class="tooltip">
            <%: item.Aya.Translate.Where(x=>x.LangId=="fa" && x.AyaId==item.Aya.Id).First().Text %>
        </span></span>(<%: item.AyaNo %>)
    <% } %>
</div>
<p align="left">
    <%if (Model.First().PageId < 604) { %>
    <a href='/Pages/<%=(Model.First().PageId + 1) %>' class="button" onclick='gopage(<%=(Model.First().PageId + 1) %>);return false;'>
        Next</a>
    <%} %>
    <%if (Model.First().PageId > 1) { %>
    <a href='/Pages/<%=(Model.First().PageId - 1) %>' class="button" onclick='gopage(<%=(Model.First().PageId - 1) %>);return false;'>
        Prev</a>
    <%} %>
</p>
