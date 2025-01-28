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
        loadIncomeAndExpenseLineChart(data);
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

    loadDoughnutChart(doughnutIncomeChart, chartLabel, chartData, barColors);
}

function loadExpenseChart(data) {
    const doughnutExpenseChart = document.getElementById('doughnutExpenseChart');
    let chartLabel = data.dashboardModel.doughnutExpenseData.map(x => x.title);
    let chartData = data.dashboardModel.doughnutExpenseData.map(x => x.amount);
    let barColors = chartLabel.map(() => getRandomColor());

    loadDoughnutChart(doughnutExpenseChart, chartLabel, chartData, barColors);
}

function loadAllTransactionsChart(data) {
    const doughnutAllTransactionsChart = document.getElementById('doughnutAllTransactionsChart');
    let chartLabel = data.dashboardModel.doughnutAllTransactionsData.map(x => x.title);
    let chartData = data.dashboardModel.doughnutAllTransactionsData.map(x => x.amount);
    let barColors = chartLabel.map(() => getRandomColor());

    loadDoughnutChart(doughnutAllTransactionsChart, chartLabel, chartData, barColors);
}

function loadIncomeAndExpenseLineChart(data) {
    const doughnutLineChart = document.getElementById('doughnutLineChart');

    let combinedData = [...data.dashboardModel.lineChartCategoryTypeData.incomeData, ...data.dashboardModel.lineChartCategoryTypeData.expenseData];

    let sortedData = combinedData.sort((a, b) => {
        if (a.yearTransaction === b.yearTransaction) {
            return a.monthTransaction - b.monthTransaction;
        }
        return a.yearTransaction - b.yearTransaction;
    });

    let labels = [...new Set(
        sortedData.map(
            (item) => `${item.title.substring(0, 3).toUpperCase()} ${item.yearTransaction}`
        )
    )];

    let incomeAmount = labels.map(label => {
        const match = data.dashboardModel.lineChartCategoryTypeData.incomeData.find(
            item => `${item.title.substring(0, 3).toUpperCase()} ${item.yearTransaction}` === label
        );
        return match ? match.amount : 0;
    });

    let expenseAmount = labels.map(label => {
        const match = data.dashboardModel.lineChartCategoryTypeData.expenseData.find(
            item => `${item.title.substring(0, 3).toUpperCase()} ${item.yearTransaction}` === label
        );
        return match ? match.amount : 0;
    });

    loadLineChart(doughnutLineChart, incomeAmount, expenseAmount, labels);
}

function loadDoughnutChart(chart, chartLabel, chartData, barColors) {
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

function loadLineChart(chart, incomeAmount, expenseAmount, transactionsDate) {
    new Chart(chart, {
        type: 'line',
        data: {
            labels: [...transactionsDate],
            datasets: [
                {
                    label: ' Receitas',
                    data: incomeAmount,
                    borderColor: 'green',
                    backgroundColor: 'green',
                    tension: 0.1
                },
                {
                    label: ' Despesas',
                    data: expenseAmount,
                    borderColor: 'red',
                    backgroundColor: 'red',
                    tension: 0.1
                }
            ]
        },
        options: {
            scales: {
                x: {
                    grid: {
                        color: 'rgba(255, 255, 255, 0.08)',
                    },
                    ticks: {
                        color: 'white',
                        font: {
                            size: 14
                        }
                    }
                },
                y: {
                    grid: {
                        color: 'rgba(255, 255, 255, 0.08)',
                    },
                    ticks: {
                        color: 'white',
                        font: {
                            size: 14
                        }
                    }
                }
            },
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