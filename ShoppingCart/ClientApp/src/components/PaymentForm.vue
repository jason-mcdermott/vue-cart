﻿<template>
    <div>
        <div v-show="!transactionComplete" class="payment-form">
            <form @submit.prevent="submitForm">
                <table>
                    <tr>
                        <td colspan="6">
                            <span>Credit Card Info</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <input type="text" id="cardnumber" required name="cardnumber" v-model="cardnumber" 
                                   placeholder="1111-1111-1111-1111" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <input type="text" id="month" required name="month" v-model="month" 
                                   placeholder="MM" pattern="^[0-9]{2}$" title="2 digit month" />
                        </td>
                        <td colspan="4">
                            <input type="text" id="year" required v-model="year" placeholder="YYYY"
                                   pattern="^[0-9]{4}$" title="4 digit year" />
                        </td>
                        <td colspan="1">
                            <input type="text" id="cvv" required v-model="cvv" placeholder="CVV" 
                                   pattern="^[0-9]{3}$" title="3 digit security code"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <span>Billing Address</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <input type="text" required v-model="firstname" placeholder="First Name" 
                                   pattern="[A-Za-z]+" title="only letters allowed" />
                        </td>
                        <td colspan="3">
                            <input type="text" required v-model="lastname" placeholder="Last Name" 
                                   pattern="[A-Za-z]+" title="only letters allowed" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <input type="text" required v-model="address" placeholder="Address" />
                        </td>
                        <td colspan="3">
                            <input type="text" required v-model="city" placeholder="City" 
                                   pattern="[A-Za-z]+" title="only letters allowed" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <input type="text" required v-model="state" placeholder="State" 
                                   pattern="[A-Za-z]{2}" title="two letter abbreviation" />
                        </td>
                        <td colspan="3">
                            <input type="text" required v-model="zip" placeholder="Zip" 
                                   pattern="^[0-9]{5}$" title="5 digit zip" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <input type="text" required v-model="country" placeholder="Country" 
                                   pattern="[A-Za-z]{3}" title="three letter country code" />
                        </td>
                    </tr>
                </table>
                <input type="submit" name="Submit Payment" value="Submit Payment" />
            </form>
        </div>

        <div v-if="errors.length > 0" class="errors">
            <ul v-for="error in errors">
                <li>{{error}}</li>
            </ul>
        </div>
        <div v-else-if="transactionComplete" class="summary">
            <div>
                <h3>Transaction Summary</h3>
                <table id="transaction-summary">
                    <thead>
                        <tr>
                            <th>Product</th>
                            <th>Description</th>
                            <th>Price</th>
                            <th>Quantity</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="item in summary.purchasedItems">
                            <td>{{ item.name }}</td>
                            <td>{{ item.description }}</td>
                            <td>{{ item.price | currency }}</td>
                            <td style="text-align:center">{{ item.quantity }}</td>
                        </tr>
                    </tbody>
                </table>
                <span>Total: {{ totalCost | currency }}</span>
                <h3>Shipping Information</h3>
                <table id="shipping-address">
                    <tr>
                        <td> {{ firstname }} {{ lastname }}</td>
                    </tr>
                    <tr>
                        <td> {{ address }}</td>
                    </tr>
                    <tr>
                        <td> {{ city }} {{ state }} {{ zip }} </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'
    import { Store } from '../state/Store'

    export default {
        data() {
            return {
                cardnumber: '', 
                month: '',
                year: '',
                cvv: '',
                firstname: '',
                lastname: '',
                address: '',
                city: '',
                state: '',
                zip: '',
                country: '',
                errors: [],
                summary: {
                    purchasedItems: [],
                    totalCost: ''
                },
                transactionComplete: false
            }
        },
        computed: {
            totalCost() {
                return Store.totalCost
            }
        },
        methods: {
            submitForm() {
                axios.post('http://localhost:60568/api/order', {
                    'items': Store.$data.cartItems,
                    'paymentinfo': {
                        'creditcard': {
                            'cardnumber': this.cardnumber,
                            'month': this.month,
                            'year': this.year,
                            'cvv': this.cvv
                        },
                        'address': {
                            'name': `${this.firstname} ${this.lastname}`,
                            'address1': this.address,
                            'city': this.city,
                            'state': this.state,
                            'zipcode': this.zip,
                            'country': this.country
                        }
                    }
                },{
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(response => {
                    if (response.data.hasErrors) {
                        this.errors = response.data.errors
                    }
                    else {
                        this.summary = response.data
                        Store.$data.transactionComplete = this.transactionComplete = true;
                    }
                })
                .catch(e => {
                    this.errors.push(e)
                })

            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

    .payment-form {
        width: 600px;
        margin-left: auto;
        margin-right: auto;
    }

    .errors {
        color: #FF0000;
    }

    .errors li {
        list-style-type: none;
        padding: 0;
    }

    #transaction-summary {
        width: 500px;
        margin-left: auto;
        margin-right: auto;
        text-align: left;
        padding-bottom: 20px;
    }

    #shipping-address {
        margin-left: auto;
        margin-right: auto;
        text-align: left;
        padding-bottom: 20px;
    }

    input#cvv {
        width: 100%;
    }

    input#month {
        width: 100%;
    }

    input#year {
        width: 100%;
    }


    input[type=text], select {
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        display: inline-block;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

    input[type=submit] {
        width: 100%;
        background-color: #5DBCD2;
        padding: 14px 20px;
        margin: 8px 0;
        border: none;
        border-radius: 4px;
        color: white;
        cursor: pointer;
        font-size: 16px;
    }

    input[type=submit]:hover {
        background-color: #4798aa;
    }

    div {
        border-radius: 5px;
        background-color: #f2f2f2;
        padding: 20px;
    }

</style>
