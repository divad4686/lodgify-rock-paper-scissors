var apiUrl = "http://lodgify-rps.azurewebsites.net/api/Play/playOneGame/";
$(function()
{
    $(".playOption").click(function(){
        $(".playOption").attr('disabled','')
        $(this).removeAttr('disabled');
        $(this).removeClass('btn-default');
        $(this).addClass('btn-primary');

        var val = $(this).attr('value');
        
        var url = apiUrl + val;
        $.getJSON(val,null,function(data){
            console.log(data.result);
        });
    });
});