<template>
    <div class="hello">
        <h1>{{ msg }}</h1>
        <p>
            Ipsum Lorem Dolor
        </p>
        <h3>Items</h3>
        <button type="button" v-on:click="EmptyCart">Empty Cart</button>
        <button type="button" v-on:click="GetData">Get Data</button>
        <ul id="example-1">
            <li v-for="item in items">
                {{ item.name }} | {{ item.description}} | {{ item.price }}
            </li>
        </ul>

    </div>
</template>
<script>
    export default {
        name: 'ShoppingCart',
        props: {
            msg: String
        },
        data() {
            return {
                items: [
                    { name: "Widget 1", description: "A widget", price: 4.00 },
                    { name: "Widget 2", description: "A widget", price: 5.00 },
                    { name: "Widget 3", description: "A widget", price: 6.00 }
                ]
            };
        },
        methods: {
            EmptyCart() {
                this.items = [];
            },
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
