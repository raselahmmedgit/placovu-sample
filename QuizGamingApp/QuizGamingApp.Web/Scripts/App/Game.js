$Game = {
    bindGameModeSelectionEvent: function () {

        $(".game-mode").on('click',
            function () {
                var selectedGameModeId = $(this).attr('data-game-mode-id');
                $(".game-mode-description").each(function () {
                    $(this).hide();
                });
                $(".game-mode").each(function () {
                    $(this).removeClass("active");
                });
                $(this).addClass("active");
                $("#game_mode_description_" + selectedGameModeId).show();
                $("#selectedGameModeId").val(selectedGameModeId);
            });
    },
    bindQuizQuestionEvents: function () {

        $(".btn-add-question-to-game").on('click',
            function () {
                $Game.addQuestion(false);
            });

        $(".btn-save-question-to-template").on('click',
            function () {
                $Game.addQuestion(true);
            });

        this.bindQuestionItemEvent();
        this.selectedFirstQuestionItem();
        this.bindQuestionReorderEvent();
        this.hideShowQuestionDeleteIcon();

        $(".btn-update-question").on('click',
            function () {
                $Game.updateQuestion();
            });

        $(".btn-add-new-question").on('click',
            function () {
                $Game.OnQuestionAddMode();
            });
        $(".btn-add-question-from-template").on('click',
            function () {
                $Game.loadQuestionFromTemplate();
            });

        $(".btn-question-save-and-continue").on('click',
            function () {
                $Game.addQuestionsToGame();
            });

        $(".game-question-delete-icon").on('click',
            function () {
                if (confirm("Are you sure to delete it?")) {
                    $Game.removeQuestionFromGame($("#QuestionId").val());
                    $Game.selectedFirstQuestionItem();
                    $Game.hideShowQuestionDeleteIcon();
                    App.ToastrNotifierSuccess("Question removed from game!");
                }
            });

    },
    bindQuestionItemEvent: function () {
        $(".question-item").on('click',
            function () {
                $(".question-item").removeClass("active");
                $(this).addClass("active");
                $(".question-display-position").text($(this).attr('data-question-display-order'));
                $Game.bindQuestionEditFormData(this);
            });
    },
    bindTemplateQuestionItemEvent: function () {
        $(".template-question-item").on('click',
            function () {
                $(this).toggleClass("active");
            });

        $(".btn-add-selected-question-to-game").on('click',
            function () {
                //alert('Hello World');
                $Game.addSelectedTemplateQuestionToGame();
            });
    },
    bindGameSkinEvent: function () {

        var source = document.querySelector('#BackgroundColor');
        var picker = new CP(source);
        source.onclick = function (e) {
            e.preventDefault();
        };
        picker.on("change",
            function (color) {
                this.source.value = '#' + color;
                $("#BackgroundColorCode").val('#' + color);
                //this.source.style.backgroundColor = '#' + color;
            });
        var brand = document.getElementById('LogoImage');
        brand.className = 'attachment_upload';
        brand.onchange = function () {
            //document.getElementById('fileUpload').value = this.value.substring(12);
        };

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.img-preview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }

        $("#LogoImage").change(function () {
            readURL(this);
        });

    },
    //GameCoupon
    bindGameCouponEvent: function () {

        $('body').on('click',
            '.game-coupon-rewarddistributiontype',
            function (e) {
                var selectedRewardDistributionTypeId = $(this).attr('data-game-coupon-rewarddistributiontypeid');
                $(".game-coupon-rewarddistributiontype").each(function () {
                    $(this).removeClass("active");
                });
                $(this).addClass("active");
                $("#RewardDistributionTypeId").val(selectedRewardDistributionTypeId);
            });

        $('body').on('click',
            '.game-coupon-rewardingplayertype',
            function (e) {
                var selectedRewardingPlayerTypeId = $(this).attr('data-game-coupon-rewardingplayertypeid');
                $(".game-coupon-rewardingplayertype").each(function () {
                    $(this).removeClass("active");
                });
                $(this).addClass("active");
                $("#RewardingPlayerTypeId").val(selectedRewardingPlayerTypeId);
            });

        $('body').on('click',
            '#btn-add-selected-coupon-to-game',
            function (e) {
                App.LoaderShow();

                var selectedGameCouponId = $("#AddGameCoupon_SelectedGameCouponId").val();

                if (selectedGameCouponId == null || selectedGameCouponId == "")
                {
                    App.AppLayoutMessageErrorById("GameCouponMessage", "At least one coupon is required. Please select one.");
                    App.LoaderHide();
                }
                else
                {
                    var gameCouponViewModel = {
                        GameId: $("#GameCoupon_GameId").val(),
                        SelectedGameCouponId: selectedGameCouponId
                    };

                    $.ajax({
                        url: "/Game/AddGameCoupon",
                        type: 'POST',
                        dataType: "html",
                        data: gameCouponViewModel,
                        beforeSend: function () {
                        },
                        success: function (result) {
                            App.LoaderHide();
                            $("#GameCoupon").html("");
                            $("#GameCoupon").html(result);
                            $('#AddGameCouponFromTemplateModal').modal('hide');
                        },
                        error: function (error) {
                            App.LoaderHide();
                            console.log(error);
                        }

                    });
                }

            });

        $('body').on('click',
            '.btn-select-game-coupon-to-game ',
            function (e) {
                App.LoaderShow();

                var btnAddGameCoupon = $(this);
                $(".btn-select-game-coupon-to-game ").each(function () {
                    $(this).removeClass("active");
                });
                $(this).addClass("active");
                var selectedGameCouponId = btnAddGameCoupon.data("gamecouponid");
                $("#AddGameCoupon_SelectedGameCouponId").val(selectedGameCouponId);

                App.LoaderHide();
            });

        $('body').on('click',
            '#btn-delete-game-coupon-from-game',
            function (e) {
                App.LoaderShow();

                var gameId = $("#GameCoupon_GameId").val();
                var gameCouponId = $("#GameCoupon_GameCouponId").val();

                if (gameCouponId == null || gameCouponId == "") {

                } else {
                    var gameCouponViewModel = {
                        gameId: gameId,
                        gameCouponId: gameCouponId
                    };

                    $.ajax({
                        url: "/Game/DeleteGameCoupon",
                        type: 'POST',
                        dataType: "html",
                        data: gameCouponViewModel,
                        beforeSend: function () {
                        },
                        success: function (result) {
                            App.LoaderHide();
                            $("#GameCoupon").html("");
                            $("#GameCoupon").html(result);

                            $(".btn-add-game-coupon").each(function () {
                                $(this).removeClass("active");
                            });
                            $("#AddGameCoupon_SelectedGameCouponId").val('');

                        },
                        error: function (error) {
                            App.LoaderHide();
                            console.log(error);
                        }

                    });
                }
            });

        $('body').on('click',
            '.btn-add-new-coupon',
            function (e) {
                $Game.loadGameCoupon();
            });

        $('body').on('click',
            '.btn-add-coupon-from-template',
            function (e) {
                $Game.loadGameCouponFromTemplate();
            });

        $('body').on('click',
            '.btn-add-game-coupon-to-game',
            function (e) {

                var formId = ('#formAddGameCoupon');

                var couponTitle = $(formId).find('input[name="CouponTitle"]').val();
                var prizeMoney = $(formId).find('input[name="PrizeMoney"]').val();
                var startDate = $(formId).find('input[name="StartDate"]').val();
                var endDate = $(formId).find('input[name="EndDate"]').val();

                if ((couponTitle == null || couponTitle == "")) {
                    App.AppLayoutMessageErrorById("AddGameCouponModalMessage", "Title Required");
                }
                else if ((prizeMoney == null || prizeMoney == "")) {
                    App.AppLayoutMessageErrorById("AddGameCouponModalMessage", "Prize Money Required");
                }
                else if ((startDate == null || startDate == "")) {
                    App.AppLayoutMessageErrorById("AddGameCouponModalMessage", "Start Date Required");
                }
                else if ((endDate == null || endDate == "")) {
                    App.AppLayoutMessageErrorById("AddGameCouponModalMessage", "End Date Required");
                }
                else {
                    var isFormValid = $(formId).valid();

                    if (isFormValid) {
                        $(formId).submit();
                    }
                }

            });

    },
    loadGameCoupon: function () {

        App.LoaderShow();

        var gameId = $("#GameCoupon_GameId").val();

        $.ajax({
            url: ("/GameCoupon/AddGameCoupon?id=" + gameId),
            type: 'GET',
            dataType: "html",
            beforeSend: function () {
                //OpenAppProgressModal();
            },
            success: function (result) {
                $("#AddGameCouponModalPlaceHolder").html(result);
                $("#AddGameCouponModal").modal("show");
                App.LoaderHide();
            },
            error: function (error) {
                App.LoaderHide();
                console.log(error);
            }

        });
    },
    onAddGameCouponModalBegin: function () {
        App.LoaderShow();
    },
    onAddGameCouponModalComplete: function () {
        App.LoaderHide();
    },
    onAddGameCouponModalFailure: function () {
    },
    onAddGameCouponModalSuccess: function (data) {
        $("#GameCoupon").html("");
        $("#GameCoupon").html(data);
        $("#AddGameCouponModal").modal("hide");
        
    },
    bindAddGameCouponModalDatetimePicker: function (result) {
        $('#dp_StartDate').datetimepicker({
            format: "MM/DD/YYYY"
        });

        $('#dp_EndDate').datetimepicker({
            format: "MM/DD/YYYY"
        });
    },
    loadGameCouponFromTemplate: function () {

        App.LoaderShow();

        var gameId = $("#GameCoupon_GameId").val();

        $.ajax({
            url: ("/GameCoupon/AddGameCouponTemplate?id=" + gameId),
            type: 'GET',
            dataType: "html",
            beforeSend: function () {
                //OpenAppProgressModal();
            },
            success: function (result) {
                $("#AddGameCouponFromTemplateModalPlaceHolder").html(result);
                $("#AddGameCouponFromTemplateModal").modal("show");
                App.LoaderHide();
            },
            error: function (error) {
                App.LoaderHide();
                console.log(error);
            }

        });
    },
    formSubmitGameCoupon: function (currentStepId, currentStepFormId) {

        App.LoaderShow();

        var selectedGameCouponId = $("#GameCoupon_GameCouponId").val();

        if (selectedGameCouponId == null || selectedGameCouponId == "")
        {
            App.AppLayoutMessageErrorById("GameCouponMessage", "At least one coupon is required. Please select one.");

            App.LoaderHide();
        }
        else
        {
            App.LoaderShow();

            var formId = ('#' + currentStepFormId);
            var isFormValid = $(formId).valid();
            if (isFormValid) {
                $(formId).submit();
            }
        }

    },
    //GameCoupon
    //GamePlayerLogin
    bindGamePlayerLoginEvent: function () {

        $('body').on('click',
            '.game-playerlogintype',
            function (e) {
                var selectedPlayerLoginTypeId = $(this).attr('data-game-playerlogintypeid');
                $(".game-playerlogintype").each(function () {
                    $(this).removeClass("active");
                });
                $(this).addClass("active");
                $("#PlayerLoginTypeId").val(selectedPlayerLoginTypeId);

                $('.PlayerLoginTypeDetail').hide();
                var showId = ('#PlayerLoginTypeDetail_' + selectedPlayerLoginTypeId);
                $(showId).show();

            });

    },
    //GamePlayerLogin
    bindQuestionEditFormData: function (element) {
        $("#QuestionTitle").val($('.question-text',element).text());
        $("#QuestionId").val($(element).attr('data-question-id'));
        $("#CurrectAnswer").val($(element).attr('data-correct-answer'));
        $("#FirstWrongAnswerText").val($(element).attr('data-first-wrong-answer'));
        $("#SecondWrongAnswerText").val($(element).attr('data-second-wrong-answer'));
        $(".btn-add-question-to-game").hide();
        $(".btn-save-question-to-template").hide();
        $(".btn-update-question").show();
        var selectedQuestionIndex = parseInt($("span.question-count-label", element).text());
        $(".question-display-position").html(selectedQuestionIndex);

    },
    OnQuestionAddMode: function () {
        $("#QuestionTitle").val("");
        $("#QuestionId").val("");
        $("#CurrectAnswer").val("");
        $("#FirstWrongAnswerText").val("");
        $("#SecondWrongAnswerText").val("");
        $(".btn-add-question-to-game").show();
        $(".btn-save-question-to-template").show();
        $(".btn-update-question").hide();
    },

    addQuestion: function (IsTemplateQuestion) {
        var quizQuestionViewModel = {
            GameId: $("#Id").val(),
            IsTemplateQuestion: IsTemplateQuestion,
            QuestionText: $("#QuestionTitle").val(),
            QuestionAnswer: {
                CorrectAnswerText: $("#CurrectAnswer").val(),
                FirstWrongAnswerText: $("#FirstWrongAnswerText").val(),
                SecondWrongAnswerText: $("#SecondWrongAnswerText").val()
            }
        };
        App.LoaderShow();
        $.ajax({
            url: "/Question/Create",
            type: 'POST',
            dataType: "html",
            data: quizQuestionViewModel,
            beforeSend: function () {
                //OpenAppProgressModal();
            },
            success: function (result) {
                App.LoaderHide();
                if (IsTemplateQuestion) {
                    App.ToastrNotifierSuccess("Question added to template");
                } else {
                    $("#gameQuestionList").html(result);
                    $Game.bindQuestionItemEvent();
                    $Game.hideShowQuestionDeleteIcon();
                    $Game.selectedLastQuestionItem();
                    $Game.bindQuestionReorderEvent();
                    var questionCount = parseInt($("#questionCount").text());
                    $("#questionCount").html(++questionCount);
                }
            },
            error: function (error) {
                console.log(error);
            }

        });
    },
    updateQuestion: function () {

        var question = {
            GameId: $("#Id").val(),
            Id: $("#QuestionId").val(),
            QuestionText: $("#QuestionTitle").val(),
            QuestionAnswer: {
                CorrectAnswerText: $("#CurrectAnswer").val(),
                FirstWrongAnswerText: $("#FirstWrongAnswerText").val(),
                SecondWrongAnswerText: $("#SecondWrongAnswerText").val()
            }
        }
        App.LoaderShow();
        $.ajax({
            url: "/Question/Edit",
            type: 'POST',
            dataType: "html",
            data: question,
            beforeSend: function () {
                //OpenAppProgressModal();
            },
            success: function (result) {
                App.LoaderHide();
                $("#gameQuestionList").html(result);
                $Game.bindQuestionItemEvent();
            },
            error: function (error) {
                console.log(error);
            }

        });
    },
    addQuestionsToGame: function (currentStepId, nextStepId) {

        var questionList = [];
        var questionCount = 0;
        $(".question-item").each(function () {
            var question = {
                Id: $(this).attr('data-question-id'),
                IsSelected: true,
                DisplayOrder: ++questionCount
            }
            questionList.push(question);
        });
        if (questionCount == 0) {
            App.ToastrNotifierError("Oops! You must have at least 1 question to proceed!");
            return;
        }

        var Game = {
            Id: $("#Id").val(),
            Questions: questionList
        }
        App.LoaderShow();
        $.ajax({
            url: "/Game/AddGameQuestions",
            type: 'POST',
            dataType: "html",
            data: Game,
            beforeSend: function () {
                //OpenAppProgressModal();
            },
            success: function (result) {
                App.LoaderHide();
                AppMultiStepForm.StepShow(currentStepId, nextStepId);
            },
            error: function (error) {
                App.LoaderHide();
                console.log(error);
            }

        });
    },
    loadQuestionFromTemplate: function () {

        App.LoaderShow();
        $.ajax({
            url: "/Question/TemplateQuestions",
            type: 'GET',
            dataType: "html",
            beforeSend: function () {
                //OpenAppProgressModal();
            },
            success: function (result) {
                App.LoaderHide();
                $("#QuestionFromTemplateModalPlaceHolder").html(result);
                $Game.bindTemplateQuestionItemEvent();
                $("#questionsFromTemplateModal").modal("show");
            },
            error: function (error) {
                App.LoaderHide();
                console.log(error);
            }

        });
    },
    addSelectedTemplateQuestionToGame: function () {
        var providedQuestion = 0;
        var addedQuestion = 0;
        var questionCount =  parseInt($("#questionCount").text());
        $(".template-question-item.active").each(function () {
            providedQuestion++;
            questionCount++;
            var listItem = '<li class="question-item ui-state-default"' +
                'data-question-id="' +
                $(this).attr('data-question-id') +
                '"' +
                'data-correct-answer="' +
                $(this).attr('data-correct-answer') +
                '"' +
                'data-first-wrong-answer="' +
                $(this).attr('data-first-wrong-answer') +
                '"' +
                'data-second-wrong-answer="' +
                $(this).attr('data-second-wrong-answer') +
                '"><span class="question-count-label">' + (questionCount) + '</span><i class="fa fa-bars" style="color: #b0b0b3 !important;'+
                'padding-right: 15px; padding-left: 15px;" aria-hidden="true"></i><span class="question-text">' +
                $(this).text() +
                '</span></li>';

            if (!$Game.checkIfQuestionAlreadyAdded($(this).attr('data-question-id'))) {
                addedQuestion++;
                $(".question-list").append(listItem);
                $Game.bindQuestionItemEvent();
                $Game.bindQuestionReorderEvent();
            }

        });
        $("#questionCount").html(questionCount);

        $("#questionsFromTemplateModal").modal('toggle');
        if (providedQuestion === addedQuestion) {
            App.ToastrNotifierSuccess('Selected question(s) added to the game!');
        }
        else if (addedQuestion === 0) {
            App.ToastrNotifierError('Selected question(s) already exist in the game!');
        }
        else {
            App.ToastrNotifierSuccess(addedQuestion + ' question(s) added and ' + (providedQuestion - addedQuestion) + ' question(s) already exist in the game!');
        }
    },
    selectedFirstQuestionItem: function () {
        var firstItem = $(".question-item:first-child");
        $(firstItem).addClass("active");
        $Game.bindQuestionEditFormData(firstItem);
    },
    selectedLastQuestionItem: function () {
        var firstItem = $(".question-item:last-child");
        $(firstItem).addClass("active");
        $Game.bindQuestionEditFormData(firstItem);
    },
    bindQuestionReorderEvent: function () {
        $(".question-list").sortable();
        $(".question-list").disableSelection();
    },
    removeQuestionFromGame: function (questionId) {
        $(".question-list li[data-question-id=" + questionId + "]").remove();
    },
    hideShowQuestionDeleteIcon: function () {
        if ($('.question-list li').length > 0) {
            $(".game-question-delete-icon").show();
        } else {
            $(".game-question-delete-icon").hide();
            $Game.OnQuestionAddMode();
        }
    },
    validateGameModeForm: function () {
        var gameModeId = $("#selectedGameModeId").val();
        var itemCount = 0;
        var valueProvidedFor = 0;
        $(".input-for-game-mode-" + gameModeId).each(function () {
            itemCount++;
            if ($(this).val() > 0) {
                valueProvidedFor++;
            }
        });

        if (itemCount === valueProvidedFor) {
            return true;
        }
        return false;

    },
    checkIfQuestionAlreadyAdded: function (questionId) {
        var isQuestionExist = false;
        $(".question-item").each(function () {
            if ($(this).attr('data-question-id') === questionId)
                isQuestionExist = true;
        });
        return isQuestionExist;
    },
    deleteGame: function (gameId) {
        var data = {
            Id: gameId
        };
        var answer = confirm("Are you sure to delete this game?");
        if (answer) {
            App.LoaderShow();
            $.ajax({
                url: "/Game/Delete",
                type: 'POST',
                data: data,
                dataType: "html",
                beforeSend: function () {
                    //OpenAppProgressModal();
                },
                success: function (result) {
                    App.LoaderHide();
                    $("#gameListReplaceDiv").html(result);
                    App.ToastrNotifierSuccess("Game Deleted Successfully!");
                },
                error: function (error) {
                    App.LoaderHide();
                    console.log(error);
                }

            });
        }
    },
    bindGameEvents: function () {
        $(".btn-game-delete").on('click', function () {
            var selectedGameId = $(this).attr('data-game-id');
            $Game.deleteGame(selectedGameId);
        });
    }


}
