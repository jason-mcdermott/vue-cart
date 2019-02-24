<template>
    <div class="">
        <h1>{{ msg }}</h1>
        <p>These are the products we currently have available.</p>
        <p>Thanks for stopping by!</p>
        <h3>Items</h3>
        <button type="button" v-on:click="EmptyCart">Empty Cart</button>
        <button type="button" v-on:click="GetData">Get Data</button>
        <table id="products">
            <thead>
                <tr>
                    <th>Product</th>
                    <th scope="col">Description</th>
                    <th scope="col">Price</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in items">
                    <td>{{ item.name }}</td>
                    <td>{{ item.description }}</td>
                    <td>{{ item.price }}</td>
                    <td><button type="button" v-on:click="AddToCart(item)">Add</button></td>+
                </tr>
            </tbody>
        </table>

    </div>
</template>
<script>
    export default {
        name: 'Products',
        props: {
            msg: String,
            //]
        },
        data() {
            return {
                items: this.GetData(),
                //items: [
                //    { name: "Widget 1", description: "A widget", price: 4.00 },
                //    { name: "Widget 2", description: "A widget", price: 5.00 },
                //    { name: "Widget 3", description: "A widget", price: 6.00 }
                //]
            };
        },
        methods: {
            GetData() {
                this.items = [];
                axios({
                    method: 'GET',
                    url: 'http://localhost:60568/api/products',
                    data: this.$data,
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(response => response.data).then(data => {
                    console.log(data);
                    this.items = data;
                }).catch(err => {
                    console.log(`There was an error submitting your form. See details: ${err}`);
                });
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
