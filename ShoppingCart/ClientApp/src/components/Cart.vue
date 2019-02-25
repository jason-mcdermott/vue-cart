<template>
    <div>
        <table id="cart">
            <thead>
                <tr>
                    <th>Product</th>
                    <th>Description</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
               <tr v-for="item in cartItems">
                    <td>{{ item.details.name }}</td>
                    <td>{{ item.details.description }}</td>
                    <td>{{ item.details.price | currency }}</td>
                    <td>{{ item.quantity }}</td>
                    <td>
                        <button type="button" id="decrement" @click="decrement(item.details.id)"> - </button>
                        <button type="button" id="remove" @click="removeFromCart(item.details.id)">Remove Item</button>
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

    table {
        font-family: Arial, Helvetica, sans-serif;
        border-collapse: collapse;
        border-radius: 10px;
        width: 600px;
        margin-left: auto;
        margin-right: auto;
    }

    th {
        padding-top: 12px;
        padding-bottom: 12px;
        text-align: left;
        padding: 8px;
        background-color: #1b3e77;
        color: white;
    }

    td {
        border: 1px solid #ddd;
        padding: 8px;
        text-align: left;
    }

    button {
        border-radius: 10px;
        background-color: #5DBCD2;
        border: none;
        color: white;
        padding: 5px 20px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
    }

    button:hover {
        background-color: #4798aa;
    }

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
