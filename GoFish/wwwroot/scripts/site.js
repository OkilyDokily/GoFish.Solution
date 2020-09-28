$(document).ready(function () {
  let chooseRank = false;
  let choosePlayer = false;
  let result = window.location.pathname.split("/");
  let num = result.slice(-1)[0];
 
 $(".hand img").click(function (e) { 
   e.preventDefault();
 
   chooseRank = $(this).attr("class");
   $(".pair").removeClass("outline");
   $(".hand img").removeClass("outline");
   $(".hand img." + chooseRank).addClass("outline");
 });
 
 $(".pair").click(function (e) { 
    e.preventDefault();

    chooseRank = $(this).attr("id");
    $(".hand img").removeClass("outline");
    $(".pair").removeClass("outline");
    $(".pair#" + chooseRank).addClass("outline");
  });

  $(".player").click(function (e) { 
    e.preventDefault();
   
    choosePlayer =  $(this).attr("id");

    if(chooseRank)
    {
      $.post("/player/" + num, "rank=" + chooseRank +"&" + "playertwo=" + choosePlayer,function(d,s,x){ window.location.href="/player/" + num;},"text");
    }
  });
});