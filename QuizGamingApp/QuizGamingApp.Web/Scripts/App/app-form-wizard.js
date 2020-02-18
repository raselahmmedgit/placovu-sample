
var appMultiStepFormStep = {
    StepGameMode: 'GameMode',
    StepGameQuestion: 'GameQuestion',
    StepGamePlayerLogin: 'GamePlayerLogin',
    StepGamePlayerMessage: 'GamePlayerMessage',
    StepGameCoupon: 'GameCoupon',
    StepGameSkin: 'GameSkin',
    StepSeven: 'Seven',
    StepEight: 'Eight',
    StepNine: 'Nine',
    StepTen: 'Ten',
    StepDone: 'Done'
};

var AppMultiStepForm = function () {

    var backButton = function (btnBack) {

        var tabId = btnBack.data("tabid");
        var previousStepId = btnBack.data("previousstepid");
        var currentStepId = btnBack.data("currentstepid");

        backStep(currentStepId, previousStepId);

    };

    var backStep = function (currentStepId, previousStepId) {

        stepShow(currentStepId, previousStepId);

    };

    var nextButton = function (btnNext) {

        var tabId = btnNext.data("tabid");
        var nextStepId = btnNext.data("nextstepid");
        var currentStepId = btnNext.data("currentstepid");
        var currentStepFormId = btnNext.data("currentstepformid");

        nextStep(currentStepId, nextStepId, currentStepFormId);

    };

    var nextStep = function (currentStepId, nextStepId, currentStepFormId) {

        if (appMultiStepFormStep.StepGameMode == currentStepId) {
            if ($Game.validateGameModeForm()) {
                stepFormSubmit(currentStepId, currentStepFormId);
            }
            else {
                App.ToastrNotifierError("Please provide selected game mode value");
                return;
            }
            
        }
        else if (appMultiStepFormStep.StepGameQuestion == currentStepId) {
            $Game.addQuestionsToGame(currentStepId, nextStepId);
            //stepShow(currentStepId, nextStepId);
            $Game.bindGamePlayerLoginEvent();
        }
        else if (appMultiStepFormStep.StepGamePlayerLogin == currentStepId) {
            stepFormSubmit(currentStepId, currentStepFormId);
        }
        else if (appMultiStepFormStep.StepGamePlayerMessage == currentStepId) {
            stepFormSubmit(currentStepId, currentStepFormId);
        }
        else if (appMultiStepFormStep.StepGameCoupon == currentStepId) {
            $Game.formSubmitGameCoupon(currentStepId, currentStepFormId);
        }
        else if (appMultiStepFormStep.StepGameSkin == currentStepId) {
            stepShow(currentStepId, nextStepId);
        }
        else {
            //for done
            if (appMultiStepFormStep.StepDone == currentStepId) {
                alert("Done");
            }
        }

    };

    var stepFormSubmit = function (currentStepId, currentStepFormId) {

        var formId = ('#' + currentStepFormId);

        var isFormValid = $(formId).valid();

        if (isFormValid) {
            $(formId).submit();
        }

    };

    var stepShow = function (currentStepId, stepShowId) {

        $('.tab').hide();
        var showId = ('#GameStep_' + stepShowId);
        $(showId).show();

        $('.step').hide();
        var currentId = ('#GameStepCount_' + stepShowId);
        $(currentId).show();
        $(currentId).addClass('active');

    };

    var stepBegin = function () {

        App.LoaderShow();

    }

    var stepFailure = function (response) {

        if (response != undefined || response != null) {

            if (response.success == false) {

                App.AppLayoutMessage(response.errortype, response.error);

            }

        }
        //check null

    }

    var stepSuccess = function (currentStepId, stepId, response) {

        if (response != undefined || response != null) {

            if (response.success == false) {

                App.AppLayoutMessage(response.errortype, response.error);

            }
            else {

                stepShow(currentStepId, stepId);

            }

        }
        //check null

    }

    var stepComplete = function () {
        App.LoaderHide();
    }

    var initializeStepShow = function (stepShowId) {

        var showId = ('#GameStep_' + stepShowId);
        $(showId).show();

        var currentId = ('#GameStepCount_' + stepShowId);
        $(currentId).addClass('active');

    };

    var actionHandler = function () {

        $('body').on('click', '.btn-game-step-back', function (e) {
            var btnBack = $(this);
            backButton(btnBack);
        });

        $('body').on('click', '.btn-game-step-next', function (e) {
            var btnNext = $(this);
            nextButton(btnNext);
        });

    };

    var initializeApp = function () {
        initializeStepShow("GameMode");
        actionHandler();
    };

    return {
        Init: initializeApp,

        StepBegin: stepBegin,
        StepFailure: stepFailure,
        StepSuccess: stepSuccess,
        StepComplete: stepComplete,

        StepShow: stepShow

    };
}();

$(document).ready(function () {

    AppMultiStepForm.Init();

});