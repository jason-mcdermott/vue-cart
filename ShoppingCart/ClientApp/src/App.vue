<template>
    <div id="app">
        <img alt="Vue logo" src="./assets/cart_large.png">
        <h1>Welcome to VueCart</h1>
        <transition name="fade">
            <ProductList v-if="showProducts" />
        </transition>
        <!--<ProductList />-->
        <transition name="fade">
            <div v-if="totalCost > 0">
                <Cart />
                <div id="cost">Total Cost: {{ totalCost | currency }}</div>
                <button @disabled="totalCost <= 0" @click="toggleForm()">Enter Payment Info</button>
            </div>
        </transition>
        <transition name="fade">
            <PaymentForm v-if="showPayment" />
        </transition>
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
        },
        data() {
            return {
                showPayment: false,
                showProducts: true
            }
        },
        methods: {
            toggleForm: function () {
                this.showPayment = !this.showPayment
            }
        },
    }
</script>

<style>

    body {
        background-color: #f2f2f2;
    }

    .fade-enter-active, .fade-leave-active {
        transition: opacity .5s;
    }

    /* .fade-leave-active below version 2.1.8 */
    .fade-enter, .fade-leave-to  {
        opacity: 0;
    }

    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
        padding: 0 0 50px;
    }

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

    #cost {
        padding: 0 0 20px;
    }
</style>