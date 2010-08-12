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
            font-family: Tahoma;
            font-size: 9pt;
            max-width: 300px;
            text-align: justify;
            background-color: #5a85a5;
            color: white;
            min-height: 30px;
            line-height: 130%;
            opacity: 0.9;
        }
    </style>
    <div id="pagecontent" >
<%Html.RenderPartial("PagePartial", Model); %>
    </div>
    <script type="text/javascript">
        $(document).ready(dotoo());

        function dotooltip() {
            $(".aya").hover(
		    function () { $(this).contents("span:last-child").css({ display: "block" }); },
		    function () { $(this).contents("span:last-child").css({ display: "none" }); }
	    );
            $(".aya").mousemove(function (e) {
                var mousex = e.pageX + 10;
                var mousey = e.pageY + 5;
                $(this).contents("span:last-child").css({ top: mousey, left: mousex });
            });
        }

        function gopage(pageno) {
            $.get("/PagesPartial/" + pageno, function (data) {
                $("#pagecontent").html(data);
                dotooltip();
            });
        }
    </script>
</asp:Content>
