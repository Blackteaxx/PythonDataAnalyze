from django.shortcuts import render


def runoob(request):
    context = {'hello': 'Hello World!'}
    return render(request, 'runoob.html', context)


def node_tree(request):
    """
    发挥节点构成的树
    """
    return render(request, 'tree_base.html', {})
