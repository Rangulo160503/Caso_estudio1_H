﻿document.addEventListener("DOMContentLoaded", () => {
    const canvas = document.getElementById("gameCanvas");
    const ctx = canvas.getContext("2d");
    const grid = 20;
    let count = 0;
    let snake = {
        x: 160,
        y: 160,
        dx: grid,
        dy: 0,
        cells: [],
        maxCells: 4
    };
    let food = {
        x: 320,
        y: 320
    };

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min)) + min;
    }

    function resetGame() {
        snake.x = 160;
        snake.y = 160;
        snake.cells = [];
        snake.maxCells = 4;
        snake.dx = grid;
        snake.dy = 0;
        food.x = getRandomInt(0, 25) * grid;
        food.y = getRandomInt(0, 25) * grid;
    }

    function loop() {
        requestAnimationFrame(loop);

        if (++count < 4) {
            return;
        }

        count = 0;
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        snake.x += snake.dx;
        snake.y += snake.dy;

        if (snake.x < 0 || snake.x >= canvas.width || snake.y < 0 || snake.y >= canvas.height) {
            endGame();
            return;
        }

        snake.cells.unshift({ x: snake.x, y: snake.y });

        if (snake.cells.length > snake.maxCells) {
            snake.cells.pop();
        }

        ctx.fillStyle = 'red';
        ctx.fillRect(food.x, food.y, grid - 1, grid - 1);

        ctx.fillStyle = 'green';
        snake.cells.forEach((cell, index) => {
            ctx.fillRect(cell.x, cell.y, grid - 1, grid - 1);

            if (cell.x === food.x && cell.y === food.y) {
                snake.maxCells++;
                food.x = getRandomInt(0, 25) * grid;
                food.y = getRandomInt(0, 25) * grid;
            }

            for (let i = index + 1; i < snake.cells.length; i++) {
                if (cell.x === snake.cells[i].x && cell.y === snake.cells[i].y) {
                    endGame();
                    return;
                }
            }
        });
    }

    document.addEventListener("keydown", (e) => {
        if (e.which === 37 && snake.dx === 0) {
            snake.dx = -grid;
            snake.dy = 0;
        } else if (e.which === 38 && snake.dy === 0) {
            snake.dy = -grid;
            snake.dx = 0;
        } else if (e.which === 39 && snake.dx === 0) {
            snake.dx = grid;
            snake.dy = 0;
        } else if (e.which === 40 && snake.dy === 0) {
            snake.dy = grid;
            snake.dx = 0;
        }
    });

    function endGame() {
        const score = snake.maxCells - 4;
        const duration = new Date() - startTime;

        alert('Game Over! Your score: ' + score);
        resetGame();
    }

    resetGame();
    requestAnimationFrame(loop);
});
