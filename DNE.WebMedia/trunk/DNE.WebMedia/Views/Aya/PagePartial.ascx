<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<DNE.WebMedia.Model.PageAyaSimple>>" %>
<% int pageno = int.Parse(Html.ViewContext.RouteData.Values["pageno"].ToString());
   string langid = "fa";
   if (Request["langid"] != null)
       langid = Request["langid"].ToString();
%>
<div align="left">
    <%if (pageno < 604) { %>
    <a href='/Pages/<%=(pageno + 1) %>' class="button" onclick='gopage(<%=(pageno + 1) %>,"<%=langid %>");return false;'>
        Next</a>
    <%} %>
    <%if (pageno > 1) { %>
    <a href='/Pages/<%=(pageno - 1) %>' class="button" onclick='gopage(<%=(pageno - 1) %>,"<%=langid %>");return false;'>
        Prev</a>
    <%} %>
    <a href="#" class="button" onclick="pop(this)">Go To Page</a> 
    <a href="#" class="button" onclick="pop2(this)">Go To Sura</a> 

    <div id="popup" >
        <div id="actions"><a href="#" class="prev">&laquo; Back</a> <a href="#" class="next">Forward &raquo;</a>
        </div>
        <!-- root element for scrollable -->
        <div class="scrollable vertical">
            <!-- root element for the items -->
            <div class="items" id="result"></div>
        </div>
    </div>
     <div id="popup2" >
        <div id="actions"><a href="#" class="prev">&laquo; Back</a> <a href="#" class="next">Forward &raquo;</a>
        </div>
        <!-- root element for scrollable -->
        <div class="scrollable vertical" style="width:170px;">
            <!-- root element for the items -->
            <div class="items" id="result2"></div>
        </div>
    </div>
    <span id="loading" style="">
        <img class="loading" alt="" src="/img/1.gif" style="display: inline;" />
    </span><span id="play-info"></span></div>
<div style="direction: rtl; text-align: justify;padding: 10px;">
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
<div id="jpId"></div>
<textarea id="tem" style="visibility: hidden;">
{#for k = 0 to 5}
    <div>
    {#for i = 0 to 9}
        <div class="item" >
            {#for j = 1 to 10}
                <a href="#" onclick="gopage(this.id);" class="x" id='{$T.k*100 + $T.i * 10 + $T.j}'>{$T.k*100 + $T.i * 10 + $T.j}</a>
            {#/for}
        </div>
    {#/for}
    </div>
{#/for}
    <div>
        <div class="item">
            {#for j = 1 to 4}
                <a href="#" onclick="gopage(this.id);" class="x" id='{600 + $T.j}'>{600 + $T.j}</a>
            {#/for}
        </div>
    </div>
</textarea>
 <textarea id="tem2" style="visibility: hidden;">
    {#for index = 0 to 11}
        <div class="item" >
        {#foreach $T.table as record begin=$T.index*10 count=10}
		<div>
			<span>{$T.record.id}</span>.
			<a href="/pages/{$T.record.from}" onclick="gopage({$T.record.from});return false;">{$T.record.name}</a>
			
			
		</div>
		{#/for}
        </div>
    {#/for}
    </textarea>
<script src="/Scripts/sura.js" type="text/javascript"></script>
<script type="text/javascript">
var jpPlayInfo = $("#play-info");
$(document).ready(function(){
    
    $("#popup").hide();
    $("#popup2").hide();
    /*  Page Index  */
    $(".scrollable").scrollable({ vertical: true, mousewheel: true });

    $("#result").setTemplate($("#tem").val());
    $("#result").processTemplate(suradata);

    $("#result2").setTemplate($("#tem2").val());
    $("#result2").processTemplate(suradata);

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
	});

    

});

function pop(c) {
    var position = $(c).position();
    var left = position.left;
    var top = position.top;
    var h = $(c).height();
    var w = $(c).width();
    $('#popup').css({ position: "absolute",
            marginLeft: 0, marginTop: 0,
            top: top+h+20, left: left+w+20});
    $('#popup').slideToggle();
    
}
function pop2(c) {
    var position = $(c).position();
    var left = position.left;
    var top = position.top;
    var h = $(c).height();
    var w = $(c).width();
    $('#popup2').css({ position: "absolute",
            marginLeft: 0, marginTop: 0,
            top: top+h+20, left: left+w+20});
    $('#popup2').slideToggle();
    
}
function gotranslate() {
    gopage(<%=pageno%>);
}
</script>
