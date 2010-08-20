<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<AyaSimple>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Sura: <%:Model.First().Sura %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style="direction: rtl; text-align: justify;">
    <h2><%:Model.First().Sura %></h2>
    <%if (Model.First().SuraId != 9) { %><h3>بِسْمِ اللَّهِ الرَّحْمَٰنِ الرَّحِيمِ</h3><%} %>
    <div>
        <% foreach (var item in Model) { %>
        <span class="aya">
            <%: item.TextFull %>
            <span class="tooltip">
                <%: item.Translate %>
            </span>
        </span>
        (<%: item.AyaId %>)
        <% } %>
    </div>
</div>
    <script type="text/javascript">
    $(document).ready(function () {
        $(".aya").hover(
		    function () { $(this).contents("span:last-child").css({ display: "block" }); },
		    function () { $(this).contents("span:last-child").css({ display: "none" }); }
	    );
        $(".aya").mousemove(function (e) {
            var mousex = e.pageX + 10;
            var mousey = e.pageY + 5;
            $(this).contents("span:last-child").css({ top: mousey, left: mousex });
        });
    });
    </script>
</asp:Content>
