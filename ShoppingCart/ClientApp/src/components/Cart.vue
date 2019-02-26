<template>
    <div class="shopping-cart">
        <table id="cart">
            <thead>
                <tr>
                    <th colspan="4" style="text-align:center">Cart</th>
                </tr>
            </thead>
            <tbody>
               <tr v-for="item in cartItems">
                    <td>{{ item.name }}</td>
                    <!--<td>{{ item.description }}</td>-->
                    <td>{{ item.price | currency }}</td>
                    <td>{{ item.quantity }}</td>
                    <td>
                        <button type="button" id="decrement" @click="decrement(item.id)"> - </button>
                        <button type="button" id="remove" @click="removeFromCart(item.id)">Remove Item</button>
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

    .shopping-cart {
        padding: 20px 0 20px;
    }

    table {
        font-family: Arial, Helvetica, sans-serif;
        border-collapse: collapse;
        border-radius: 10px;
        width: 400px;
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
        /*border-radius: 4px;*/
        /*background-color: #5DBCD2;*/
        border: none;
        color: white;
        padding: 5px 20px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
    }

    #decrement {
        border-radius: 4px 0 0 4px;
        padding: 5px 10px 5px 10px;
    }

    #remove {
        border-radius: 0 4px 4px 0;
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
