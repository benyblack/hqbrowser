<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Holy Quran Browser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewData["Message"] %></h2>
    <p>
        Welcome to Holy Quran Browser.<br />
        For browsing text and translation plz go to <a href="/Pages/">this</a>. <br />
        For audio plz click on each verse then wait to load & play.<br />
        Main Text: <a rel="external" href="http://tanzil.info/">tanzil.info</a><br />
        translation source: <a rel="external" href="http://zekr.org/">zekr.org</a><br />
        audio source: <a rel="external" href="http://www.everyayah.com/">EveryAyah</a> <br />
        with voice of <a rel="external" href="http://en.wikipedia.org/wiki/Abdul_Basit_'Abd_us-Samad">Mohammad Abdulbaset AbdulSamad</a><br />
        (New) Api Using Samples: <a rel="external" href="/ApiSamples/a.htm" style="color:Orange">Demo</a>


    </p>

</asp:Content>
