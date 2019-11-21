
$(document).ready(function () {
    LoadChartData('line');

    $("input[type=radio]").change(function () {
        RebindChart();
        var selectedChartType = $(this).val();
        if (selectedChartType !== null && selectedChartType != "") {
            LoadChartData(selectedChartType);
        }

    });
    
    $("#printOut").click(function () {
        printCanvas();
    });

    function LoadChartData(chartType) {
        var fillChartStatus = chartType === 'bar' ? true : false;

        var chartData = {
            ChartType: chartType,
            ChartName: "IPSS ( International Prostate Symptom Score)",
            Labels: ["Pre-op", "6 Weeks", "3 months", "6 months", "9 months"],
            DataSets: [
                {
                    LabelName: 'Patient',
                    DataList: [6, 11, 3, 24, 14],
                    ToolTipData: [[{ "QuestionShortName": "Emptying", "Score": 6 }, { "QuestionShortName": "Frequency", "Score": 7 }, { "QuestionShortName": "urgency", "Score": 8 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 11 }, { "QuestionShortName": "Frequency", "Score": 12 }, { "QuestionShortName": "urgency", "Score": 13 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 3 }, { "QuestionShortName": "Frequency", "Score": 4 }, { "QuestionShortName": "urgency", "Score": 5 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 24 }, { "QuestionShortName": "Frequency", "Score": 25 }, { "QuestionShortName": "urgency", "Score": 26 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 14 }, { "QuestionShortName": "Frequency", "Score": 15 }, { "QuestionShortName": "urgency", "Score": 16 }]],
                    GraphProperty: {
                        Fill: fillChartStatus,
                        BorderWidth: 5,
                        BackgroundColor: "#804FA8",
                        PointRadius: 5,
                        PointBorderWidth: 5,
                        LineTension: 0,
                        PointBorderColor: "#804FA8",
                        BorderColor: "#804FA8",
                        PointBackgroundColor: "#FFF",
                    }
                },
                {
                    LabelName: 'Gaertner Patient',
                    DataList: [7, 20, 9, 12, 2],
                    ToolTipData: [[{ "QuestionShortName": "Emptying", "Score": 15 }, { "QuestionShortName": "Frequency", "Score": 16 }, { "QuestionShortName": "urgency", "Score": 25 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 25 }, { "QuestionShortName": "Frequency", "Score": 26 }, { "QuestionShortName": "urgency", "Score": 15 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 4 }, { "QuestionShortName": "Frequency", "Score": 5 }, { "QuestionShortName": "urgency", "Score": 5 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 12 }, { "QuestionShortName": "Frequency", "Score": 25 }, { "QuestionShortName": "urgency", "Score": 26 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 7 }, { "QuestionShortName": "Frequency", "Score": 15 }, { "QuestionShortName": "urgency", "Score": 16 }]],
                    GraphProperty: {
                        Fill: fillChartStatus,
                        BorderWidth: 5,
                        BackgroundColor: "#4BC0C0",
                        PointRadius: 5,
                        PointBorderWidth: 5,
                        LineTension: 0,
                        PointBorderColor: "#4BC0C0",
                        BorderColor: "#4BC0C0",
                        PointBackgroundColor: "#FFF",
                    }
                },
                {
                    LabelName: 'All Minnesota urology Patient',
                    DataList: [15, 15, 8, 25, 10],
                    ToolTipData: [[{ "QuestionShortName": "Emptying", "Score": 9 }, { "QuestionShortName": "Frequency", "Score": 5 }, { "QuestionShortName": "urgency", "Score": 25 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 14 }, { "QuestionShortName": "Frequency", "Score": 10 }, { "QuestionShortName": "urgency", "Score": 3 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 6 }, { "QuestionShortName": "Frequency", "Score": 2 }, { "QuestionShortName": "urgency", "Score": 21 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 26 }, { "QuestionShortName": "Frequency", "Score": 23 }, { "QuestionShortName": "urgency", "Score": 26 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 16 }, { "QuestionShortName": "Frequency", "Score": 13 }, { "QuestionShortName": "urgency", "Score": 6 }]],
                    GraphProperty: {
                        Fill: fillChartStatus,
                        BorderWidth: 5,
                        BackgroundColor: "#70BF41",
                        PointRadius: 5,
                        PointBorderWidth: 5,
                        LineTension: 0,
                        PointBorderColor: "#70BF41",
                        BorderColor: "#70BF41",
                        PointBackgroundColor: "#FFF",
                    }
                },
                {
                    LabelName: 'All',
                    DataList: [15, 17, 4, 22, 13],
                    ToolTipData: [[{ "QuestionShortName": "Emptying", "Score": 18 }, { "QuestionShortName": "Frequency", "Score": 14 }, { "QuestionShortName": "urgency", "Score": 16 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 22 }, { "QuestionShortName": "Frequency", "Score": 6 }, { "QuestionShortName": "urgency", "Score": 13 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 3 }, { "QuestionShortName": "Frequency", "Score": 8 }, { "QuestionShortName": "urgency", "Score": 10 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 12 }, { "QuestionShortName": "Frequency", "Score": 12 }, { "QuestionShortName": "urgency", "Score": 12 }],
                                  [{ "QuestionShortName": "Emptying", "Score": 7 }, { "QuestionShortName": "Frequency", "Score": 15 }, { "QuestionShortName": "urgency", "Score": 8 }]],
                    GraphProperty: {
                        Fill: fillChartStatus,
                        BorderWidth: 5,
                        BackgroundColor: "#EA8817",
                        PointRadius: 5,
                        PointBorderWidth: 5,
                        LineTension: 0,
                        PointBorderColor: "#EA8817",
                        BorderColor: "#EA8817",
                        PointBackgroundColor: "#FFF",
                    }
                }
            ],

        }
        PopulateChart(chartData);

    }
                
    function RebindChart() {
            $("#myChart").remove();
            $("#chart_container").append('<canvas style="background-color:##fff;padding-top:50px" id="myChart"></canvas>')

        }

    function PopulateChart(chartData) {
        var ctx = document.getElementById('myChart').getContext('2d');
        var chart = new Chart(ctx, {
            // The type of chart we want to create
            type: chartData.ChartType,

            // The data for our dataset
            data: {
                labels: chartData.Labels,
                datasets: GetPopulatedDataSet(chartData.DataSets),

            },

            // Configuration options go here
            options: {
                responsive: true,
                scales: {
                    xAxes: [{
                        ticks: {
                            fontSize: 15,
                            fontStyle: "bold"

                        },
                        gridLines: {
                            zeroLineWidth: 3,
                            zeroLineColor: "#000",

                        },
                         
                    }],
                    yAxes: [{
                        ticks: {
                            fontSize: 15,
                            fontStyle: "bold",
                            
                        },
                        gridLines: {
                            zeroLineWidth: 3,
                            zeroLineColor: "#000",
                            drawTicks: true,
                            tickMarkLength: 15,

                        },

                    }]

                },
                title: {
                    display: true,
                    text: chartData.ChartName,
                    fontSize: 20,
                    fontFamily: "Raleway",
                },
                legend: {
                    labels: {
                        usePointStyle: true,
                        pointStyle: "round",
                        fontSize: 15,
                        fontFamily: "Raleway",
                        
                    }

                },
                tooltips: {
                    backgroundColor: '#F7BB29',
                    bodyFontColor: "#000",
                    titleFontColor: "#000",
                    caretPadding: 10,
                    xPadding: 10,
                    yPadding: 10,
                    mode: 'nearest',
                    position: 'nearest',
                    titleFontSize: 15,
                    bodyFontSize: 15,
                    titleFontFamily: "Raleway",
                    bodyFontFamily: "Raleway",
                    titleSpacing: 8,
                    bodySpacing: 8,
                    displayColors: false,
                    callbacks: {

                        title: function (tooltipItem, data) {
                            title = data.datasets[tooltipItem[0].datasetIndex].label + " : " + tooltipItem[0].yLabel + " (" + tooltipItem[0].xLabel + " )";
                            return title;
                        },
                        label: function (tooltipItem, data) {
                            var label = data.datasets[tooltipItem.datasetIndex].label || '';

                            if (label) {
                                label += ': ';
                            }
                            label += tooltipItem.yLabel;
                            var dataArray = [];
                            var tooltipData = data.datasets[tooltipItem.datasetIndex].toolTipData[tooltipItem.index];
                            var size = tooltipData != undefined ? tooltipData.length : 0;
                            var toolTipItem = '';
                            for (var i = 0; i < size; i++) {
                                //toolTipItem += tooltipData[i].QuestionShortName + " : " + tooltipData[i].Score + " ";
                                var item = "\u27A4 " + tooltipData[i].QuestionShortName + " : " + tooltipData[i].Score + " ";
                                dataArray.push(item);
                            }
                                
                            //return toolTipItem;
                            return dataArray;

                        },

                    }

                },
                animation: {
                    duration: 1000

                },
                hover: {
                    animationDuration: 0

                }

            }
        });

    }

    function GetPopulatedDataSet(series) {
        var dataSets = [];
        for (var i = 0; i < series.length; i++) {

            var data = {
                label: series[i].LabelName,
                data: series[i].DataList,
                toolTipData: series[i].ToolTipData,
                fill: series[i].GraphProperty.Fill,
                borderWidth: series[i].GraphProperty.BorderWidth,
                backgroundColor: series[i].GraphProperty.BackgroundColor,
                pointRadius: series[i].GraphProperty.PointRadius,
                borderColor: series[i].GraphProperty.BorderColor,
                pointBorderColor: series[i].GraphProperty.PointBorderColor,
                pointBackgroundColor: series[i].GraphProperty.PointBackgroundColor,
                pointBorderWidth: series[i].GraphProperty.PointBorderWidth,
                lineTension: series[i].GraphProperty.LineTension

            }
            dataSets.push(data);
        }
        return dataSets;
    }

    function printCanvas() {
        var dataUrl = document.getElementById('myChart');
        console.log(dataUrl);
        var windowContent = '<!DOCTYPE html>';
        windowContent += '<html>'
        windowContent += '<head><title>Ontrack Health</title></head>';
        windowContent += '<body>'
        windowContent += '<img src="' + dataUrl.toDataURL() + '">';
        windowContent += '<footer style="float:right;margin-top:100px"><div><img height=30;width=50 src="http://73.164.15.207:7979/ontrackhealth/AppImages/placovu_logo.png"></div></footer>';
        windowContent += '</body>';
        windowContent += '</html>';
        var printWin = window.open('', '', 'width=' + screen.width, 'height=' + screen.height);
        printWin.document.open();
        printWin.document.write(windowContent);
        setTimeout(function () {
            printWin.document.close();
            printWin.focus();
            printWin.print();
            printWin.close();
        }, 250);

    }

    //function printDiv(divName) {
    //    var printContents = document.getElementById(divName).innerHTML;
    //    var originalContents = document.body.innerHTML;

    //    document.body.innerHTML = printContents;

    //    window.print();

    //    document.body.innerHTML = originalContents;
    //}

});


Chart.Legend.prototype.afterFit= function () {
    // this is custom implementation written by Nahid on 27th July, 2017
    this.height = this.height + 25;
};

