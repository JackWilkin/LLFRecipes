
// Declare the Blueport namespace
var Scripts = Scripts || {};

// Declare the Blueport.RetailerAPI namespace
Scripts.RecipeApi = Scripts.RecipeApi || {};

//  Blueport namespace definition
(function(recipeApi) {
    "use strict";

    recipeApi.AppleCrisp = function() {
        return $.ajax({
           url:  '/api/recipe/applecrisp,
           cache: false,
           type: 'GET',
           contentType: 'application/json; charset=utf-8',
           suppressErrors: true
        });
    }

})(Scripts.RecipeApi)