SlotMachine = function (buttonElement, balanceElement, reels, random, networkClient) {
    this.buttonElement = buttonElement;
    this.balanceElement = balanceElement;
    this.reels = reels;
    this.random = random;
    this.networkClient = networkClient;
    this.balance = 0;
};

SlotMachine.prototype.render = function () {
    this.buttonElement.disabled = true;
    this.buttonElement.value = 'Pay to play';
    this.balanceElement.innerHTML = 0;
    for (var i = 0; i < this.reels.length;) {
        this.reels[i++].src = 'images/' + this.random() + '.jpg';
    }
};