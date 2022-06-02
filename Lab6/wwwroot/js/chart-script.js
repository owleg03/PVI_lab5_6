let chart = document.getElementById('chart').getContext('2d');
let figuresCount = {
    whiteKingCount: 0,
    whiteQueenCount: 0,
    whiteRookCount: 0,
    whiteBishopCount: 0,
    whiteKnightCount: 0,
    whitePawnCount: 0,
    blackKingCount: 0,
    blackQueenCount: 0,
    blackRookCount: 0,
    blackBishopCount: 0,
    blackKnightCount: 0,
    blackPawnCount: 0,
};
updateFiguresCount();
let chessFiguresChart = new Chart(chart, {
    type:'pie',
    data: {
        labels: [
            'White King', 'White Queen', 'White Rook', 'White Bishop', 'White Knight', 'White Pawn',
            'Black King', 'Black Queen', 'Black Rook', 'Black Bishop', 'Black Knight', 'Black Pawn',
        ],
        datasets: [
            {
                data: Object.values(figuresCount),
                backgroundColor: [
                    'red', 'blue', 'yellow', 'purple', 'green', 'orange',
                    'grey', 'coral', 'chocolate', 'brown', 'cyan', 'bisque'
                ],
                label : 'Chess Figures'
            }
        ],
    }
});
function updateChart() {
    updateFiguresCount();
    chessFiguresChart.data.datasets[0].data = Object.values(figuresCount);
}
function updateFiguresCount() {
    const chessTableCells = document.getElementById('chess-deck').getElementsByTagName('td');
    for (let i = 0, tile; tile = chessTableCells[i]; ++i) {
        if (tile.classList.contains('white-king-tile')) {
            figuresCount.whiteKingCount++;
            continue;
        }
        if (tile.classList.contains('white-queen-tile')) {
            figuresCount.whiteQueenCount++;
            continue;
        }
        if (tile.classList.contains('white-rook-tile')) {
            figuresCount.whiteRookCount++;
            continue;
        }
        if (tile.classList.contains('white-bishop-tile')) {
            figuresCount.whiteBishopCount++;
            continue;
        }
        if (tile.classList.contains('white-knight-tile')) {
            figuresCount.whiteKnightCount++;
            continue;
        }
        if (tile.classList.contains('white-pawn-tile')) {
            figuresCount.whitePawnCount++;
            continue;
        }
        if (tile.classList.contains('black-king-tile')) {
            figuresCount.blackKingCount++;
            continue;
        }
        if (tile.classList.contains('black-queen-tile')) {
            figuresCount.blackQueenCount++;
            continue;
        }
        if (tile.classList.contains('black-rook-tile')) {
            figuresCount.blackRookCount++;
            continue;
        }
        if (tile.classList.contains('black-bishop-tile')) {
            figuresCount.blackBishopCount++;
            continue;
        }
        if (tile.classList.contains('black-knight-tile')) {
            figuresCount.blackKnightCount++;
            continue;
        }
        if (tile.classList.contains('black-pawn-tile')) {
            figuresCount.blackPawnCount++;
            continue;
        }
    }
}