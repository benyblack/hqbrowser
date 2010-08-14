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
	});

});

function gotranslate(ctl) {
    gopage(<%=pageno%>,ctl.value);
}