




let apiURL = "https://forkify-api.herokuapp.com/api/v2/recipes";
let apikey = "94d9532d-ffcf-479d-ab8d-c02157491406";

async function GetRecipes(recipeName, id, isAllShow) {
    let resp = await fetch('${apiURL}?search=${recipeName}&key=${apikey}');
    let result = await resp.json();
    let Recipes = isAllShow ? result.data.recipes : result.data.recipes.slice(0, 7)
    showRecipes(Recipes, id);
}
function showRecipes(recipes, id) {
    $.ajax({
        contentType:"application/json; charset=utf-8",
        dataType: 'html',
        type: 'POST',
        url: '/Recipe/GetRecipeCard',
        data: JSON.stringify(recipes),
        success: function (htmlResult) {
            $('#' + id).html(htmlResult);
        }
    });
}