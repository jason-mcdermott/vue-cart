<template>
    <div class="product-list">
        <div v-if="errors.length > 0" class="errors">
            <ul v-for="error in errors">
                <li>{{error}}</li>
            </ul>
        </div>
        <div v-else>
            <table id="products">
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Description</th>
                        <th>Price</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in products">
                        <td>{{ item.name }}</td>
                        <td>{{ item.description }}</td>
                        <td>{{ item.price | currency }}</td>
                        <td><button @click="addToCart(item)">Add</button></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
    import { Store } from '../state/Store'
    import axios from 'axios';

    export default {
        data() {
            return {
                products: [],
                errors: []
            };
        },
        created() {
            axios.get(`http://localhost:60568/api/products`)
                .then(response => {
                    this.products = response.data
                })
                .catch(e => {
                    this.errors.push(e)
                })
        },
        methods: {
            addToCart(product){
                Store.addToCart(product)
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

    .product-list {
        padding: 0 0 20px;
    }

    .errors {
        color: #FF0000;
    }

    table {
        font-family: Arial, Helvetica, sans-serif;
        border-collapse: collapse;
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

    /*td:first-child, th:first-child {
        border-left: none;
    }*/

    /*table tr:last-child td:first-child {
        border-bottom-left-radius: 10px;
    }

    table tr:last-child td:last-child {
        border-bottom-right-radius: 10px;
    }*/

    button {
        border-radius: 4px;
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

    .errors ul {
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
