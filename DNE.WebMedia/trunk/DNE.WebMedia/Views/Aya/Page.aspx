<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DNE.WebMedia.Model.PageAya>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Page
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
	<h2>Page</h2>

	  <div style="direction: rtl; text-align: justify;">
		<% foreach (var item in Model) { %>
        <%if (item.AyaNo == 1 ) {%>
        <h3><%:item.Aya.sura %></h3><%} %>
        <%if (item.AyaNo == 1 && item.SuraNo !=9  ) {%>
        <h2>بِسْمِ اللَّهِ الرَّحْمَٰنِ الرَّحِيمِ</h2>
        <%} %>
		<span class="aya">
			<%: item.Aya.TextFull %>
			<span class="tooltip">
				<%: item.Aya.Translate.Where(x=>x.LangId=="fa" && x.AyaId==item.Aya.Id).First().Text %>
			</span>
		</span>
		(<%: item.AyaNo %>)

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

