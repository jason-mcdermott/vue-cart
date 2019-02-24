import Vue from 'vue'

export const Store = new Vue({
    data() {
        return {
            products: [],
            cartItems: []
        };
    },
    computed: {
        totalCost(){
            return this.cartItems.reduce((acc, product) => {
                return acc + product.details.price * product.quantity
            }, 0)
        }
    },
    methods: {
        addToCart(item){
            const index = this.cartItems.findIndex(cartItem => {
                return cartItem.details.id === item.id
            });

            if (index === -1) {
                this.cartItems.push({ details: item, quantity: 1 })
            } else {
                this.cartItems[index].quantity++
            }
        },
        decrement(id){
            const index = this.cartItems.findIndex(cartItem => {
                return cartItem.details.id === id
            })

            if(this.cartItems[index].quantity <= 1){
                this.cartItems.splice(index, 1)
            } 
            else {
                this.cartItems[index].quantity--
            }
        },
        removeFromCart(id) {
            for(let i = this.cartItems.length-1; i >= 0; i--){
                if(this.cartItems[i].details.id === id){
                    this.cartItems.splice(i, 1)
                }
            }
        }
    }
});