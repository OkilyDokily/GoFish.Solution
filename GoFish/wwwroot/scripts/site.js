$(document).ready(function(){
  let moves = parseInt($("#moves").val());
  setInterval(function(){
    fetch('http://localhost:5000/player/update')
    .then(function(response) {
      response.json().then(function(result){
        let servermoves = parseInt(result)
        if(servermoves > moves){
          $('input').val('');
          location.reload()
        }
      });
       
    },700);
  })
});