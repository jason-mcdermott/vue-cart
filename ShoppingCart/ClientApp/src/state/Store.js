import Vue from 'vue'

export const Store = new Vue({
    data() {
        return {
            products: [],
            cartItems: [],
            transactionComplete: false
        };
    },
    computed: {
        totalCost(){
            return this.cartItems.reduce((acc, product) => {
                return acc + product.price * product.quantity
            }, 0)
        }
    },
    methods: {
        addToCart(item){
            const index = this.cartItems.findIndex(cartItem => {
                return cartItem.id === item.id
            });

            if (index === -1) {
                item.quantity = 1
                this.cartItems.push(item)
            } else {
                this.cartItems[index].quantity++
            }
        },
        removeFromCart(id) {
            for(let i = this.cartItems.length-1; i >= 0; i--){
                if(this.cartItems[i].id === id){
                    this.cartItems.splice(i, 1)
                }
            }
        },
        decrement(id) {
            const index = this.cartItems.findIndex(cartItem => {
                return cartItem.id === id
            })

            if (this.cartItems[index].quantity <= 1) {
                this.cartItems.splice(index, 1)
            }
            else {
                this.cartItems[index].quantity--
            }
        },
    }
});