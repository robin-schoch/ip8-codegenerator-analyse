interface Expression {
    evaluate(): boolean
}

abstract class Operator<T> implements Expression {
    protected readonly left: T
    protected readonly right: T

    constructor(left: T, right: T) {
        this.left = left;
        this.right = right;
    }

    abstract evaluate()
}

class Id implements Expression {

    private readonly value: boolean
    constructor(value: boolean) {
        this.value = value;
    }

    evaluate(): boolean {
        return this.value;
    }
}

class And extends Operator<Expression> {
    evaluate(): boolean {
        return this.left.evaluate() && this.right.evaluate();
    }
}

class Or extends Operator<Expression> {
    evaluate(): boolean {
        return this.left.evaluate() || this.right.evaluate();
    }
}

class Not implements Expression {
    private readonly expression: Expression

    constructor(expression: Expression) {
        this.expression = expression;
    }

    evaluate(): boolean {
        return this.expression.evaluate();
    }
}

class Equals<T> extends Operator<T> {
    evaluate(): boolean {
        return this.right === this.left
    }
}

class Greater<T> extends Operator<T>  {
    evaluate(): boolean {
        return this.left > this.right;
    }
}

class GreaterOrEqual<T> extends Operator<T>  {
    evaluate(): boolean {
        return this.left >= this.right;
    }
}


class Smaller<T> extends Operator<T>  {
    evaluate(): boolean {
        return this.left < this.right;
    }
}


class SmallerOrEqual<T> extends Operator<T>  {
    evaluate(): boolean {
        return this.left <= this.right;
    }
}

