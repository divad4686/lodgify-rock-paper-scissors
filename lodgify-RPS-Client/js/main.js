var apiUrl = "http://lodgify-rps.azurewebsites.net/api/Play/playOneGame/";
var rockImg = "multimedia/rock.png";
var paperImg = "multimedia/paper.jpg";
var scissorsImg = "multimedia/scissors.jpg"

$(function()
{
    $(".playOption").click(function(){
        $(".playOption").attr('disabled','')
        $(this).removeAttr('disabled');
        $(this).removeClass('btn-default');
        $(this).addClass('btn-primary');

        var val = $(this).attr('value');
        
        var url = apiUrl + val;

        $('#robotMessage').text("The robot is making his choice...")

        $.ajax({
            url:url,
            jsonp:"callback",
            dataType: "jsonp",
            success:function(data){
                console.log(data.winner);
                if(data.result == "error"){
                    alert("Sorry there was an error");                    
                }else{
                    var winner = data.winner;
                    chooseRobotImage(val,winner);
                }

                $('#robotMessage').text('');
                $('#btnReset').removeClass('hidden');              
            }            
        });
    });

    $('#btnReset').click(function(){
        resetPlay();
    });
});


function resetPlay()
{
    $(".playOption").removeAttr('disabled').removeClass('btn-primary').addClass('btn-default');
    $('#btnReset').addClass('hidden');
    $('.robotOptionImage').attr('src',"");
    $('#resultMsg').text("").removeClass('text-primary  text-danger text-warning');
}

function chooseRobotImage(userPlay,winner)
{
    var elem = $('.robotOptionImage');
    var option = userPlay;   
    if(winner == 'robot'){
        option = whoBeatThis(userPlay);
        $('#resultMsg').text("You lose :(").addClass('text-danger');
    }
    else if(winner == 'user'){
        option = whoCanThisBeat(userPlay);
        $('#resultMsg').text("You win :)").addClass('text-primary');
    }else{
        $('#resultMsg').text("It is a tie :|").addClass('text-warning');
    }

    assignImage(option,elem);
}

function assignImage(val,elem)
{
    if(val == "rock")
        elem.attr('src',rockImg);
    else if(val == "paper")
        elem.attr('src',paperImg);
    else if(val == 'scissors')
        elem.attr('src',scissorsImg);
}

function whoBeatThis(option)
{
    if(option == "paper")
        return "scissors";
    else if(option == "scissors")
        return "rock";
    else if(option == "rock")
        return "paper";
}

function whoCanThisBeat(option){
    if(option == "paper")
        return "rock";
    else if(option == "scissors")
        return "paper";
    else if(option == "rock")
        return "scissors";
}