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
                    <td>{{ item.details.name }}</td>
                    <td>{{ item.details.description }}</td>
                    <td>{{ item.details.price | currency }}</td>
                    <td>{{ item.quantity }}</td>
                    <td>
                        <button type="button" v-on:click="decrement(item.details.id)"> - </button>
                        <button type="button" v-on:click="removeFromCart(item.details.id)">Remove Item</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>
<script>
    import { Store } from '../state/Store'
    
    export default {
        computed: {
            cartItems(){
                return Store.$data.cartItems
            }
        },
        methods: {
            decrement(id){
                Store.decrement(id);
            },
            removeFromCart(id){
                Store.removeFromCart(id);
            },
            addToCart(product){
                Store.addToCart(product);
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
