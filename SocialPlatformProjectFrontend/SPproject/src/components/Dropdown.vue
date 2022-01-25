<template>
    <div>
        <select
            :required="selected !== null"
            v-model="selectedOption"
            @input="
                event => {
                    $emit('input', event.target.value)
                }
            "
            class="form-select form-select-sm"
            aria-label=".form-select-sm example"
        >
            <option
                v-for="(option, name) in options"
                :key="option.name"
                :value="option"
            >
                {{ name }}
            </option>
        </select>
    </div>
</template>

<script>
export default {
    name: 'Dropdown',

    props: {
        options: {
            type: Object,
            required: true,
        },
    },

    data() {
        return {
            selected: true,
            selectedOption: null,
        }
    },
    mounted() {
        this.selectedOption = this.value
    },

    watch: {
        value: function (newValue) {
            this.selectedOption = newValue
        },
    },
}
</script>
