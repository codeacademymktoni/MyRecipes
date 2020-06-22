function ValidateComment() {
    var comment = document.getElementById("comment").value;

    if (comment == null || comment == " ") {
        alert("Please enter comment");
        return false;
    }
    else {
        return true;
    }
}

function RecipeLike(recipeId) {
    axios.post('/recipelikes/like', {
        recipeId: recipeId
    })
        .then(function (response) {
            var removeDislikeBtn = document.getElementById("btnRemoveDislike");

            if (!removeDislikeBtn.classList.contains("displayNone")) {
                DecreaseEngagementCount("dislikeCountContainer");
                SwitchDisplay("btnAddDislike", "btnRemoveDislike");
            }

            IncreaseEngagementCount("likeCountContainer");
            SwitchDisplay("btnRemoveLike", "btnAddLike");
        })
        .catch(function (error) {
            console.log(error)
        });
}

function RemoveRecipeLike(recipeId) {
    axios.post('/recipelikes/removelike', {
        recipeId: recipeId
    })
        .then(function (response) {
            DecreaseEngagementCount("likeCountContainer");
            SwitchDisplay("btnAddLike", "btnRemoveLike");
        })
        .catch(function (error) {
            console.log(error)
        });
}

function RecipeDislike(recipeId) {
    axios.post('/recipelikes/dislike', {
        recipeId: recipeId
    })
        .then(function (response) {
            debugger;
            var removeLikeBtn = document.getElementById("btnRemoveLike");

            if (!removeLikeBtn.classList.contains("displayNone")) {
                DecreaseEngagementCount("likeCountContainer");
                SwitchDisplay("btnAddLike", "btnRemoveLike");
            }

            IncreaseEngagementCount("dislikeCountContainer"); 
            SwitchDisplay("btnRemoveDislike", "btnAddDislike")
        })
        .catch(function (error) {
            console.log(error)
        });
}

function RemoveRecipeDislike() {
    alert("not implemented");
}

function IncreaseEngagementCount(elementId) {
    var likeContainer = document.getElementById(elementId);
    likeContainer.innerHTML = parseInt(likeContainer.innerHTML) + 1;
}

function DecreaseEngagementCount(elementId) {
    var likeContainer = document.getElementById(elementId);
    likeContainer.innerHTML = parseInt(likeContainer.innerHTML) - 1;
}

function SwitchDisplay(showElement, hideElement) {
    var showEl = document.getElementById(showElement);
    var hideEl = document.getElementById(hideElement);

    showEl.classList.remove("displayNone");
    hideEl.classList.add("displayNone");
}