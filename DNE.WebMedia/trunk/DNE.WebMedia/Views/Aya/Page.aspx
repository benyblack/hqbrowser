<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DNE.WebMedia.Model.PageAya>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <style>
    </style>
    <div id="pagecontent" >
<%Html.RenderPartial("PagePartial", Model); %>
    </div>
    <script type="text/javascript">
        $(document).ready(dotooltip());

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
