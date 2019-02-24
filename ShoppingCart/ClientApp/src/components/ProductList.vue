<template>
    <div>
        <table id="products">
            <thead>
                <tr>
                    <th>Product</th>
                    <th>Description</th>
                    <th>Price</th>
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
</template>
<script>
    import { Store } from '../state/Store'
    import axios from 'axios';

    export default {
        data() {
            return {
                products: []
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
