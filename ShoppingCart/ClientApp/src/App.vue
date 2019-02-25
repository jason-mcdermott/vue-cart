<template>
    <div id="app">
        <img alt="Vue logo" src="./assets/cart_large.png">
        <h1>Welcome to VueCart</h1>
        <!-- <p>These are the products we currently have available.</p> -->
        <!--<p>Thanks for stopping by</p>-->
        <ProductList />
        <hr />
        <Cart v-if="totalCost > 0" />
        <hr />
        <span>Total Cost: {{ totalCost | currency }}</span>
        <hr />
        <button :disabled="totalCost <= 0" @click="">Enter Payment Info</button>
        <PaymentForm />
    </div>
</template>

<script>
    import { Store } from './state/Store'

    export default {
        name: 'app',
        computed: {
            totalCost(){
                return Store.totalCost
            }
        }
    }
</script>

<style>
    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>