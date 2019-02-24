<template>
    <div>
        
        <table id="cart">
            <thead>
                <tr>
                    <th>Product</th>
                    <th scope="col">Description</th>
                    <th scope="col">Price</th>
                    <th scope="col">Quantity</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in cartItems">
                    <td>{{ item.name }}</td>
                    <td>{{ item.description }}</td>
                    <td>{{ item.price }}</td>
                    <td>{{ item.quantity }}</td>
                    <td><button type="button" v-on:click="RemoveFromCart(item)">Remove</button></td>
                </tr>
            </tbody>
        </table>

        <button>Proceed to checkout</button>

    </div>
</template>
<script>
    export default {
        name: 'ShoppingCart',
        props: {
           
        },
        data() {
            return {
                cartItems: []
            };
        },
        methods: {
            EmptyCart() {
                this.cartItems = [];
            },
            AddToCart(item) {
                this.cartItems.push(item);
            },
            RemoveFromCart(item) {
                //let index = this.cartItems.IndexOf(x => x.name === item.name);
                this.cartItems.$remove(0);
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>
