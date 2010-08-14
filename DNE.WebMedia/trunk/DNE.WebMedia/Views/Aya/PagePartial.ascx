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
    <span class="aya" id='<%=string.Format("{0:D3}{1:D3}", item.SuraNo, item.AyaId) %>'>
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
<script type="text/javascript">
var jpPlayInfo = $("#play-info");
$(document).ready(function(){
    $("#cbotranslate").val("<%=langid%>");
    $("#loading").hide();
    $(".aya").bind("click",function(){
        var isp = $("#jpId").jPlayer( "getData", "diag.isPlaying" ); 
        var mp3base = 'http://www.everyayah.com/data/AbdulSamad_64kbps_QuranExplorer.Com/';
        var mp3url =  mp3base + this.id + ".mp3";
        if (isp){
            $("#jpId").jPlayer("pause");
            if ($("#jpId").jPlayer( "getData", "diag.src" )==mp3url){
               jpPlayInfo.hide();
            }else{
                jpPlayInfo.show();
                $("#jpId").jPlayer("setFile", mp3url); 
                $("#jpId").jPlayer("play");
            }
        }else{
                jpPlayInfo.show();
                $("#jpId").jPlayer("setFile", mp3url); 
                $("#jpId").jPlayer("play");
        }
        
    });
    
    $("#jpId").jPlayer(
            {nativeSupport: false, 
            oggSupport: false,
            swfPath: "/Scripts/"}).jPlayer("onProgressChange", function(lp,ppr,ppa,pt,tt) {
            var stts = (this.element.jPlayer("getData", "diag.isPlaying") ? "playing" : "stopped");
 		jpPlayInfo.text(stts + " at " + parseInt(ppa)+"% "  + $.jPlayer.convertTime(pt) + " from " +  $.jPlayer.convertTime(tt) );
		//demoStatusInfo(this.element, jpStatus); // This displays information about jPlayer's status in the demo page
	});

});

function demoStatusInfo(myPlayer, myInfo) {
 var jPlayerStatus = "<p>jPlayer is ";
 jPlayerStatus += (myPlayer.jPlayer("getData", "diag.isPlaying") ? "playing" : "stopped");
 jPlayerStatus += " at time: " + Math.floor(myPlayer.jPlayer("getData", "diag.playedTime")) + "ms.";
 jPlayerStatus += " (tt: " + Math.floor(myPlayer.jPlayer("getData", "diag.totalTime")) + "ms";
 jPlayerStatus += ", lp: " + Math.floor(myPlayer.jPlayer("getData", "diag.loadPercent")) + "%";
 jPlayerStatus += ", ppr: " + Math.floor(myPlayer.jPlayer("getData", "diag.playedPercentRelative")) + "%";
 jPlayerStatus += ", ppa: " + Math.floor(myPlayer.jPlayer("getData", "diag.playedPercentAbsolute")) + "%)</p>"
 myInfo.html(jPlayerStatus);
} 
function gotranslate(ctl) {
    gopage(<%=pageno%>,ctl.value);
}
</script>
