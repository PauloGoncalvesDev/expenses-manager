$(document).ready(function () {
    loadCharts();
});

function loadCharts() {
    $.ajax({
        type: "POST",
        url: '/Dashboard/LoadCharts',
        data: "",
        contextType: "application/json; charset=utf-8",
        dataType: 'json',
        success: onSuccessResult,
        error: onError
    });

    function onSuccessResult(data) {
        loadIncomeChart(data);
        loadExpenseChart(data);
        loadAllTransactionsChart(data);
    }

    function onError(err) {
        showError('Erro ao carregar dados.');
    }
}

function loadIncomeChart(data) {
    const doughnutIncomeChart = document.getElementById('doughnutIncomeChart');
    let chartLabel = data.dashboardModel.doughnutIncomeData.map(x => x.title);
    let chartData = data.dashboardModel.doughnutIncomeData.map(x => x.amount);
    let barColors = chartLabel.map(() => getRandomColor());

    loadChart(doughnutIncomeChart, chartLabel, chartData, barColors);
}

function loadExpenseChart(data) {
    const doughnutExpenseChart = document.getElementById('doughnutExpenseChart');
    let chartLabel = data.dashboardModel.doughnutExpenseData.map(x => x.title);
    let chartData = data.dashboardModel.doughnutExpenseData.map(x => x.amount);
    let barColors = chartLabel.map(() => getRandomColor());

    loadChart(doughnutExpenseChart, chartLabel, chartData, barColors);
}

function loadAllTransactionsChart(data) {
    const doughnutAllTransactionsChart = document.getElementById('doughnutAllTransactionsChart');
    let chartLabel = data.dashboardModel.doughnutAllTransactionsData.map(x => x.title);
    let chartData = data.dashboardModel.doughnutAllTransactionsData.map(x => x.amount);
    let barColors = chartLabel.map(() => getRandomColor());

    loadChart(doughnutAllTransactionsChart, chartLabel, chartData, barColors);
}

function loadChart(chart, chartLabel, chartData, barColors) {
    new Chart(chart, {
        type: 'doughnut',
        data: {
            labels: chartLabel,
            datasets: [{
                label: ' Valor em R$',
                data: chartData,
                backgroundColor: barColors,
                hoverOffset: 10
            }]
        },
        options: {
            plugins: {
                legend: {
                    labels: {
                        color: 'white',
                        font: {
                            size: 16
                        }
                    }
                },
                tooltip: {
                    bodyFont: {
                        size: 14
                    },
                    titleFont: {
                        size: 16
                    }
                }
            }
        }
    });
}