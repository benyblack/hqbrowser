<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DNE.WebMedia.Model.PageAyaSimple>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pagecontent" >
<%Html.RenderPartial("PagePartial", Model); %>
    </div>
    <script type="text/javascript">
        $(document).ready(dotooltip());

        function dotooltip() {
            $(".aya").hover(
		    function () { $(this).contents("div:last-child").css({ display: "block" }); },
		    function () { $(this).contents("div:last-child").css({ display: "none" }); }
	    );
            $(".aya").mousemove(function (e) {
                var mousex = e.pageX + 10;
                var mousey = e.pageY + 5;
                $(this).contents("div:last-child").css({ top: mousey, left: mousex });
            });
        }

        function gopage(pageno, langid) {
            $("#loading").show();
            var url = "/PagesPartial/" + pageno;
            if (langid != "")
                url += "?langid=" + langid;

            $.get(url, function (data) {
                $("#pagecontent").html(data);
                dotooltip();
                $("#loading").hide();
            });
        }

    </script>
</asp:Content>
