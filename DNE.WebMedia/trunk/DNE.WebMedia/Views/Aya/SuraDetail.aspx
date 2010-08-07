<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DNE.WebMedia.Model.Aya>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    SuraDetail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .tooltipx
        {
            display: none;
            background: transparent url(/img/tooltip/black_arrow_big.png);
            font-size: 12px;
            font-family: Tahoma;
            height: 170px;
            width: 320px;
            padding: 25px;
            color: #fff;
            direction: rtl;
            text-align: right;
        }
        .aya
        {
            /*float:right;*/
            line-height: 200%;
            font-family: Arial;
            font-size: x-large;
        }
        .tooltip
        {
            background: #c8c8c8;
            display: none;
            padding: 10px;
            position: absolute;
            direction: rtl;
            text-align: right;
            z-index: 1000;
            -moz-border-radius: 4px;
            
            font-family:Tahoma;
            font-size: 9pt;
            
            background-color:#5a85a5;
			color:white;
			min-height:30px;
			padding:10px 20px 10px 65px;
			opacity:0.9;
        }
    </style>
    <h2>
        Sura:
        <%:Model.First().sura %>
        SuraId:
        <%:Model.First().SuraId %></h2>
    <h3>بِسْمِ اللَّهِ الرَّحْمَٰنِ الرَّحِيمِ</h3>
    <div style="direction: rtl; text-align: justify;">
        <% foreach (var item in Model) { %>
        <span class="aya">
            <%: item.TextFull %>
            <span class="tooltip">
                <%: item.Translate.Where(x=>x.LangId=="fa" && x.AyaId==item.Id).First().Text %>
            </span>
        </span>
        (<%: item.AyaId %>)
        <% } %>
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
