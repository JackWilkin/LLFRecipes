    $(function() {
    debugger;
        var list = @Html.Raw(Json.Encode(Model.Recipe.Utensils));
        var listAsString = [];
        for (i = 0; i < list.length; i++) {
            var item = list[i];
            listAsString[i] = " " + item.UtensilName;
        }

        $(".utensil-list").text(listAsString.join());

        if ("@Model.IsCelsius".toLowerCase() == "true")
        {
            $("#temperature-display").text(
                "@Model.Recipe.Celsius° Celsius"
            );
            $("#temperature-checkbox").prop( "checked", true );
        }
        else{
            $("#temperature-display").text(
                "@Model.Recipe.Fahrenheit° Fahrenheit"
            );
            $("#temperature-checkbox").prop( "checked", false );
        }

        $("#scale-input").val(@Model.Scaler);

        if ($("#scale-input").val() == 2) {
            $("#scale-button-two").prop("checked", true).trigger("click");
        }

        if ($("#scale-input").val() == .5) {
            $("#scale-button-half").prop("checked", true).trigger("click");
        }

    });

    function openNav() {
        debugger;
        document.getElementById("mySidenav").style.width = "250px";
        document.getElementById("recipe-page-body").style.marginLeft = "250px";
        document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
    }

    function closeNav() {
        document.getElementById("mySidenav").style.width = "0";
        document.getElementById("recipe-page-body").style.marginLeft= "0";
        document.body.style.backgroundColor = "white";
    }

    function customScale() {
        var x = document.getElementById("scale-input");
        if (x.style.display === "none") {
            x.style.display = "block";
        } else {
            x.style.display = "none";
        }
    }

    $('input:radio[name="radio"]').change(
        function(){
            switch ($(this).val()) {
            case "custom":
                $("#scale-input").show();
                $("#scale-custom-label").text("");
                break;
            case "double":
                $("#scale-input").hide();
                $("#scale-custom-label").text("Custom");
                $("#scale-input").val(2);
                $("#scale-input").change();
                break;
            case "half":
                $("#scale-input").hide();
                $("#scale-custom-label").text("Custom");
                $("#scale-input").val(.5);
                $("#scale-input").change();
                break;
        }
    });

    $('#temperature-checkbox').click(function() {
        if(document.getElementById('temperature-checkbox').checked) {
            $("#temperature-display").text(
                "@Model.Recipe.Celsius° Celsius"
            )
        } else {
            $("#temperature-display").text(

                "@Model.Recipe.Fahrenheit° Fahrenheit"
            )
        }
    });

    $("#scale-input").change(
        function(){
            debugger;
            var scaler = $("#scale-input").val();
            var isCelsius = document.getElementById('temperature-checkbox').checked;
            var recipeId = @Model.Recipe.RecipeId;
            var url = "/Recipe/Display?recipeId="+ recipeId +"&scaler=" + scaler +"&isCelsius=" + isCelsius;
            window.location.replace(url);
        }
    );

    
