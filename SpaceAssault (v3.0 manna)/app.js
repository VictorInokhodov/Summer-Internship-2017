/*
* I don't know, why it happend, but I can't create
* sprite object from sprite.js.
*
* So I have to copy-past code from sprite.js
* to app.js: 
*/

function Sprite(url, pos, size, speed, frames, dir, once) {
    this.pos = pos;
    this.size = size;
    this.speed = typeof speed === 'number' ? speed : 0;
    this.frames = frames;
    this._index = 0;
    this.url = url;
    this.dir = dir || 'horizontal';
    this.once = once;
};

Sprite.prototype.update = function(dt) {
    this._index += this.speed*dt;
}

Sprite.prototype.render = function(ctx) {
var frame;

if(this.speed > 0) {
    var max = this.frames.length;
    var idx = Math.floor(this._index);
    frame = this.frames[idx % max];

    if(this.once && idx >= max) {
        this.done = true;
        return;
    }
}
else {
    frame = 0;
}


var x = this.pos[0];
var y = this.pos[1];

if(this.dir == 'vertical') {
    y += frame * this.size[1];
}
else {
    x += frame * this.size[0];
}

ctx.drawImage(resources.get(this.url),
              x, y,
              this.size[0], this.size[1],
              0, 0,
              this.size[0], this.size[1]);
}

// ------------------------- END OF sprite.js ------------------------------


var canvas = document.createElement("canvas");
var ctx = canvas.getContext("2d");
canvas.width = 512;
canvas.height = 480;
document.body.appendChild(canvas);

var lastTime;
function main() {
    var now = Date.now();
    var dt = (now - lastTime) / 1000.0;

    update(dt);
    render();

    lastTime = now;
    requestAnimationFrame(main);
};

resources.load([
    'sprites.png',
    'terrain.png'
]);
resources.onReady(init);

function init() {
    terrainPattern = ctx.createPattern(resources.get('terrain.png'), 'repeat');

    document.getElementById('play-again').addEventListener('click', function() {
        reset();
    });

    reset();
    lastTime = Date.now();
    main();
}

var player = {
    pos: [0, 0],
    lastPosition: [0, 0],
    size: 39,
    sprite: new Sprite('sprites.png', [0, 0], [39, 39], 16, [0, 1])
};

var manna = [];

var megaliths = [
    {
        pos: [100, 100],
        size: 60,
        sprite: new Sprite('sprites.png', [0, 205], [64, 64],
                               2, [0, 1], 'vertical')
    },
    {
        pos: [200, 400],
        size: 64,
        sprite: new Sprite('sprites.png', [0, 205], [64, 64],
                               2, [0, 1], 'vertical')
    },
    {
        pos: [300, 200],
        size: 64,
        sprite: new Sprite('sprites.png', [0, 205], [64, 64],
                               2, [0, 1], 'vertical')
    }
];

var bullets = [];
var enemies = [];
var explosions = [];
var playerSpeed = 200;
var bulletSpeed = 500;
var enemySpeed = 100;

var lastFire = Date.now();
var gameTime = 0;
var isGameOver;
var terrainPattern;

var score = 0;
var mannaScore = 0;
var scoreEl = document.getElementById('score');
var mannaScoreEl = document.getElementById('mannaScore');

function update(dt) {
    gameTime += dt;

    handleInput(dt);
    updateEntities(dt);

    if(Math.random() < 1 - Math.pow(.993, gameTime)) {
        enemies.push({
            pos: [canvas.width,
                  Math.random() * (canvas.height - 39)],
            lastMove: 0,
            sprite: new Sprite('sprites.png', [0, 78], [80, 39],
                               6, [0, 1, 2, 3, 2, 1])
        });
    }

    if(manna.length < 10) {
        manna.push({
            pos: [GetRandom() * 1000 % 470, GetRandom() * 1000 % 430,],
            size: 49,
            sprite: new Sprite('sprites.png', [0, 156], [60, 49],
                                       8, [0, 1, 2, 3])
        });
    }

    checkCollisions();

    scoreEl.innerHTML = 'Score: ' + score;
    mannaScoreEl.innerHTML = 'Manna: ' + mannaScore;
}

function GetRandom() {
    return Math.random();
}

function handleInput(dt) {
    if(input.isDown('DOWN') || input.isDown('s')) {
        player.lastPosition[1] = player.pos[1];

        player.pos[1] += playerSpeed * dt;
    }

    if(input.isDown('UP') || input.isDown('w')) {
        player.lastPosition[1] = player.pos[1];
        
        player.pos[1] -= playerSpeed * dt;
    }

    if(input.isDown('LEFT') || input.isDown('a')) {
        player.lastPosition[0] = player.pos[0];
        
        player.pos[0] -= playerSpeed * dt;
    }

    if(input.isDown('RIGHT') || input.isDown('d')) {
        player.lastPosition[0] = player.pos[0];
        
        player.pos[0] += playerSpeed * dt;
    }

    if(input.isDown('SPACE') &&
       !isGameOver &&
       Date.now() - lastFire > 100) {
        var x = player.pos[0] + player.sprite.size[0] / 2;
        var y = player.pos[1] + player.sprite.size[1] / 2;

        bullets.push({ pos: [x, y],
                       dir: 'forward',
                       sprite: new Sprite('sprites.png', [0, 39], [18, 8]) });
        bullets.push({ pos: [x, y],
                       dir: 'up',
                       sprite: new Sprite('sprites.png', [0, 50], [9, 5]) });
        bullets.push({ pos: [x, y],
                       dir: 'down',
                       sprite: new Sprite('sprites.png', [0, 60], [9, 5]) });


        lastFire = Date.now();
    }
}

function updateEntities(dt) {
    player.sprite.update(dt);

    for(var i=0; i<bullets.length; i++) {
        var bullet = bullets[i];

        switch(bullet.dir) {
        case 'up': bullet.pos[1] -= bulletSpeed * dt; break;
        case 'down': bullet.pos[1] += bulletSpeed * dt; break;
        default:
            bullet.pos[0] += bulletSpeed * dt;
        }

        if(bullet.pos[1] < 0 || bullet.pos[1] > canvas.height ||
           bullet.pos[0] > canvas.width) {
            bullets.splice(i, 1);
            i--;
        }
    }

    for(var i=0; i<enemies.length; i++) {
        enemies[i].lastMove = enemies[i].pos[0]; 
        enemies[i].pos[0] -= enemySpeed * dt;
        enemies[i].sprite.update(dt);

        if(enemies[i].pos[0] + enemies[i].sprite.size[0] < 0) {
            enemies.splice(i, 1);
            i--;
        }
    }

    for(var i = 0; i < manna.length; i++) {
        manna[i].sprite.update(dt);
    }

    for(var i = 0; i < megaliths.length; i++) {
        megaliths[i].sprite.update(dt);
    }

    for(var i=0; i<explosions.length; i++) {
        explosions[i].sprite.update(dt);

        if(explosions[i].sprite.done) {
            explosions.splice(i, 1);
            i--;
        }
    }
}

function collides(x, y, r, b, x2, y2, r2, b2) {
    return !(r <= x2 || x > r2 ||
             b <= y2 || y > b2);
}

function boxCollides(pos, size, pos2, size2) {
    return collides(pos[0], pos[1],
                    pos[0] + size[0], pos[1] + size[1],
                    pos2[0], pos2[1],
                    pos2[0] + size2[0], pos2[1] + size2[1]);
}

function megalithsCollides(x, y, s, x2, y2, s2) {
    return (y > y2 - s + 15 &&
            y < y2 + s2 &&
            x > x2 - s &&
            x < x2 + s2);
}

function megalithsBoxCollides(pos, size, pos2, size2) {
    return megalithsCollides(pos[0], pos[1],
                    size, pos2[0], pos2[1], size2);
}

function checkCollisions() {
    checkPlayerBounds();

    for(var i = 0; i < megaliths.length; i++) {
        for(var j = 0; j < bullets.length; j++) {
            
            if(megalithsBoxCollides(bullets[j].pos, 13,
                megaliths[i].pos, megaliths[i].size)) {
                    bullets.splice(j, 1);
                    j--;
            }
        }
    }

    for(var i=0; i<enemies.length; i++) {
        var pos = enemies[i].pos;
        var size = enemies[i].sprite.size;

        for(var j = 0; j < megaliths.length; j++) {
            if(megalithsBoxCollides(pos, size[1],
                megaliths[j].pos, megaliths[j].size)) {
                    pos[0] = enemies[i].lastMove;
                    
                    pos[1] -= 1;
            }
        }

        for(var j=0; j<bullets.length; j++) {
            var pos2 = bullets[j].pos;
            var size2 = bullets[j].sprite.size;

            if(boxCollides(pos, size, pos2, size2)) {
                enemies.splice(i, 1);
                i--;

                score += 100;

                explosions.push({
                    pos: pos,
                    sprite: new Sprite('sprites.png',
                                       [0, 117],
                                       [39, 39],
                                       16,
                                       [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
                                       null,
                                       true)
                });

                bullets.splice(j, 1);
                break;
            }
        }

        if(boxCollides(pos, size, player.pos, player.sprite.size)) {
            gameOver();
        }
    }
}

function checkPlayerBounds() {
    if(player.pos[0] < 0) {
        player.pos[0] = 0;
    }
    else if(player.pos[0] > canvas.width - player.sprite.size[0]) {
        player.pos[0] = canvas.width - player.sprite.size[0];
    }

    if(player.pos[1] < 0) {
        player.pos[1] = 0;
    }
    else if(player.pos[1] > canvas.height - player.sprite.size[1]) {
        player.pos[1] = canvas.height - player.sprite.size[1];
    }

    checkPlayerMegalithsCollision();
    checkPlayerMannaCollision();
}

function checkPlayerMannaCollision() {
    for(var i = 0; i < manna.length; i++) {

        if(megalithsBoxCollides(player.pos, player.size,
            manna[i].pos, manna[i].size)) {
                manna.splice(i, 1);
                mannaScore++;
            }
    }
}

function checkPlayerMegalithsCollision() {
    for(var i = 0; i < megaliths.length; i++) {

        if(megalithsBoxCollides(player.pos, player.size, megaliths[i].pos, megaliths[i].size)) {
                    player.pos[0] = player.lastPosition[0];
                    player.pos[1] = player.lastPosition[1];
        }
    }
}

function render() {
    ctx.fillStyle = terrainPattern;
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    if(!isGameOver) {
        renderEntity(player);
    }

    renderEntities(bullets);
    renderEntities(enemies);
    renderEntities(explosions);
    renderEntities(megaliths);
    renderEntities(manna);
};

function renderEntities(list) {
    for(var i=0; i<list.length; i++) {
        renderEntity(list[i]);
    }    
}

function renderEntity(entity) {
    ctx.save();
    ctx.translate(entity.pos[0], entity.pos[1]);
    entity.sprite.render(ctx);
    ctx.restore();
}

function gameOver() {
    document.getElementById('game-over').style.display = 'block';
    document.getElementById('game-over-overlay').style.display = 'block';
    isGameOver = true;
}

function reset() {
    document.getElementById('game-over').style.display = 'none';
    document.getElementById('game-over-overlay').style.display = 'none';
    isGameOver = false;
    gameTime = 0;
    score = 0;

    enemies = [];
    bullets = [];

    player.pos = [50, canvas.height / 2];
};
