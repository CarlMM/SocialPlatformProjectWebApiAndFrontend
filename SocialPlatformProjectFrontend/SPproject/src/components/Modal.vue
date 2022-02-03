<template>
    <transition name="modal-fade">
        <div class="modal-backdrop">
            <div class="modal">
                <header class="modal-header">
                    <slot name="header"> </slot>
                    <button type="button" class="btn-close" @click="close">
                        x
                    </button>
                </header>

                <section class="modal-body">
                    <slot name="body"> </slot>
                </section>
            </div>
        </div>
    </transition>
</template>

<script>
export default {
    name: 'Modal',

    methods: {
        close() {
            this.$emit('close')
        },
    },
}
</script>
<style scoped>
.modal-backdrop {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(0, 0, 0, 0.8);
    display: flex;
    justify-content: center;
    align-items: center;
}

.modal {
    max-width: 65%;
    max-height: 75%;
    background: #f0f0f0;
    box-shadow: 2px 2px 20px 1px;
    overflow-x: auto;
    border-radius: 10px;

    display: flex;
    flex-direction: column;

    height: 100%;
    position: relative;
    margin: 0 auto;
    padding: 3em;
    -webkit-overflow-scrolling: touch;
}

.modal-header,
.modal-footer {
    padding: 5px;
    display: flex;
}

.modal-header {
    position: relative;
    color: #5c5c5c;
    justify-content: space-between;
}

.modal-footer {
    border-top: 1px solid #1fa89d;
    flex-direction: column;
    justify-content: flex-end;
}

.modal-body {
    position: relative;
    padding: 20px 10px;
}

.btn-close {
    position: absolute;
    top: 0;
    right: 0;
    border: none;
    font-size: 20px;
    padding: 10px;
    cursor: pointer;
    font-weight: bold;
    color: #3f3f3f;
    background: transparent;
}

.btn-green {
    color: white;
    background: #4aae9b;
    border: 1px solid #4aae9b;
    border-radius: 2px;
}

.modal-fade-enter,
.modal-fade-leave-to {
    opacity: 0.4;
}

.modal-fade-enter-active,
.modal-fade-leave-active {
    transition: opacity 0.2s ease;
}
</style>
