﻿using Esprima.Utils;

namespace Esprima.Ast
{
    public sealed class ArrowFunctionExpression : Expression, IFunction
    {
        private readonly NodeList<Expression> _params;

        public ArrowFunctionExpression(
            in NodeList<Expression> parameters,
            Node body,
            bool expression,
            bool strict,
            bool async)
            : base(Nodes.ArrowFunctionExpression)
        {
            Id = null;
            _params = parameters;
            Body = body;
            Generator = false;
            Expression = expression;
            Strict = strict;
            Async = async;
        }

        public Identifier? Id { get; }
        public Node Body { get; } // : BlockStatement | Expression;
        public bool Generator { get; }
        public bool Expression { get; }
        public bool Strict { get; }
        public bool Async { get; }

        public ref readonly NodeList<Expression> Params => ref _params;

        public override NodeCollection ChildNodes => GenericChildNodeYield.Yield(Params, Body);

        protected internal override void Accept(AstVisitor visitor)
        {
            visitor.VisitArrowFunctionExpression(this);
        }
    }
}
